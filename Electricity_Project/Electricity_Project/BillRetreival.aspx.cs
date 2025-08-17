using System;
using System.Collections.Generic;
using Electricity_Project;

namespace Electricity_Project
{
    public partial class BillRetreival : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void btnRetrieve_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            gvBills.DataSource = null;
            gvBills.DataBind();

            try
            {
                int count = int.Parse(txtCount.Text.Trim());
                ElectricityBoard board = new ElectricityBoard();
                List<ElectricityBill> bills = board.Generate_N_BillDetails(count);

                if (bills.Count > 0)
                {
                    gvBills.DataSource = bills;
                    gvBills.DataBind();
                }
                else
                {
                    lblError.Text = "No bills found.";
                }
            }
            catch (FormatException)
            {
                lblError.Text = "Please enter a valid number.";
            }
            catch (Exception ex)
            {
                lblError.Text = "An error occurred: " + ex.Message;
            }
        }
    }
}
