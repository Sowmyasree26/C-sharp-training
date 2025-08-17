using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Electricity_Project
{
    public class ElectricityBoard
    {
        private readonly SqlConnection conn;
        public ElectricityBoard()
        {
            DBHandler dbHandler = new DBHandler();
            conn = dbHandler.GetConnection();
        }

        public void CalculateBill(ElectricityBill ebill)
        {
            int units = ebill.UnitsConsumed;
            double amount = 0;

            if (units <= 100)
                amount = 0;
            else if (units <= 300)
                amount = (units - 100) * 1.5;
            else if (units <= 600)
                amount = 200 * 1.5 + (units - 300) * 3.5;
            else if (units <= 1000)
                amount = 200 * 1.5 + 300 * 3.5 + (units - 600) * 5.5;
            else
                amount = 200 * 1.5 + 300 * 3.5 + 400 * 5.5 + (units - 1000) * 7.5;

            ebill.BillAmount = amount;
        }

        public void AddBill(ElectricityBill ebill)
        {
            SqlCommand cmd = new SqlCommand("sp_add_electricity_bill", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@consumer_number", ebill.ConsumerNumber);
            cmd.Parameters.AddWithValue("@consumer_name", ebill.ConsumerName);
            cmd.Parameters.AddWithValue("@units_consumed", ebill.UnitsConsumed);
            cmd.Parameters.AddWithValue("@bill_amount", ebill.BillAmount);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public List<ElectricityBill> Generate_N_BillDetails(int num)
        {
            List<ElectricityBill> bills = new List<ElectricityBill>();

            SqlCommand cmd = new SqlCommand("sp_get_last_n_bills", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@count", num);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow row in dt.Rows)
            {
                ElectricityBill bill = new ElectricityBill
                {
                    ConsumerNumber = row["consumer_number"].ToString(),
                    ConsumerName = row["consumer_name"].ToString(),
                    UnitsConsumed = Convert.ToInt32(row["units_consumed"]),
                    BillAmount = Convert.ToDouble(row["bill_amount"])
                };
                bills.Add(bill);
            }
            return bills;
        }
    }
}
