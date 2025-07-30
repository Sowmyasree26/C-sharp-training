using System;
using System.Data;
using System.Data.SqlClient;

namespace ADO_Code_Challenge_1
{
    class Program
    {
        static string connectionString = "Data Source=ICS-LT-84F3D64\\SQLEXPRESS;Initial Catalog=ado_assignments;user id=sa; password=Smiley@262004";

        static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection(connectionString);
            Console.WriteLine("Enter Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Salary:");
            float salary = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Gender:");
            string gender = Console.ReadLine();

            Question1(con, name, salary, gender);

            Console.WriteLine("Enter EmpId to update salary:");
            int empid = int.Parse(Console.ReadLine());

            Question2(con, empid);

            Console.Read();
        }

        static void Question1(SqlConnection con, string name, float salary, string gender)
        {

            SqlCommand cmd = new SqlCommand("sp_employee_details", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@salary", salary);
            cmd.Parameters.AddWithValue("@gender", gender);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                Console.WriteLine("Generated EmpId: " + dr["empid"]);
                Console.WriteLine("Calculated Net Salary: " + dr["salary"]);
            }
            else
            {
                Console.WriteLine("No data returned from procedure.");
            }

            con.Close();

        }

        static void Question2(SqlConnection con, int empid)
        {
            SqlCommand cmd = new SqlCommand("sp_update_salary", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empid", empid);
            SqlParameter updatedSalaryParam = new SqlParameter();
            updatedSalaryParam.ParameterName = "@updated_salary";
            updatedSalaryParam.SqlDbType = SqlDbType.Float;
            updatedSalaryParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(updatedSalaryParam);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            Console.WriteLine("Updated Salary: " + updatedSalaryParam.Value);

            SqlCommand fetchCmd = new SqlCommand("select * from employee_details where empid = @eid", con);
            fetchCmd.Parameters.AddWithValue("@eid", empid);

            con.Open();
            SqlDataReader dr = fetchCmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Console.WriteLine("EmpId: " + dr["empid"]);
                    Console.WriteLine("Name: " + dr["name"]);
                    Console.WriteLine("Salary: " + dr["salary"]);
                    Console.WriteLine("Gender: " + dr["gender"]);
                    Console.WriteLine("Net Salary: " + dr["netsalary"]);
                }
            }
            else
            {
                Console.WriteLine("No employee found with the given EmpId.");
            }
            con.Close();
        }
    }
}
