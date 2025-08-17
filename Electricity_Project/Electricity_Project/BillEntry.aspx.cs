using System;
using System.Text;
using Electricity_Project;

namespace Electricity_Project
{
    public partial class Electricity_Bill : System.Web.UI.Page
    {
        private static int totalBills = 0;
        private static int currentBillIndex = 0;
        private static StringBuilder outputBuilder = new StringBuilder();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlBillForm.Visible = false;
                btnGoToRetrieval.Visible = false;
                lblResult.Text = "";
                outputBuilder.Clear();
            }
        }

        protected void btnStart_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            if (int.TryParse(txtBillCount.Text.Trim(), out totalBills) && totalBills > 0)
            {
                currentBillIndex = 0;
                pnlBillForm.Visible = true;
                btnGoToRetrieval.Visible = true;
                lblProgress.Text = $"Enter Consumer Details for Bill {currentBillIndex + 1} of {totalBills}";
                txtConsumerNumber.Text = "";
                txtConsumerName.Text = "";
                txtUnitsConsumed.Text = "";
                lblResult.Text = "";
                outputBuilder.Clear();
            }
            else
            {
                lblError.Text = "Please enter a valid number of bills.";
            }
        }

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            lblError.Text = "";

            ElectricityBill ebill = new ElectricityBill();
            BillValidator validator = new BillValidator();
            ElectricityBoard board = new ElectricityBoard();

            try
            {
                ebill.ConsumerNumber = txtConsumerNumber.Text.Trim();
                ebill.ConsumerName = txtConsumerName.Text.Trim();
                int units = Convert.ToInt32(txtUnitsConsumed.Text.Trim());
                string validationMessage = validator.ValidateUnitsConsumed(units);
                if (validationMessage != "Valid")
                {
                    lblError.Text = validationMessage;
                    return;
                }
                ebill.UnitsConsumed = units;
                board.CalculateBill(ebill);
                board.AddBill(ebill);
                outputBuilder.AppendLine($"{ebill.ConsumerNumber} {ebill.ConsumerName} {ebill.UnitsConsumed} Bill Amount : ₹{ebill.BillAmount}");
                currentBillIndex++;

                if (currentBillIndex < totalBills)
                {
                    lblProgress.Text = $"Enter Consumer Details for Bill {currentBillIndex + 1} of {totalBills}";
                    txtConsumerNumber.Text = "";
                    txtConsumerName.Text = "";
                    txtUnitsConsumed.Text = "";
                }
                else
                {
                    pnlBillForm.Visible = false;
                    lblProgress.Text = "All bills entered successfully.";
                    lblResult.Text = outputBuilder.ToString().Replace("\n", "<br/>");
                }
            }
            catch (FormatException ex)
            {
                lblError.Text = ex.Message;
            }
            catch (ArgumentException ex)
            {
                lblError.Text = ex.Message;
            }
            catch (Exception ex)
            {
                lblError.Text = "An error occurred: " + ex.Message;
            }
        }
        protected void btnGoToRetrieval_Click(object sender, EventArgs e)
        {
            Response.Redirect("BillRetreival.aspx");
        }
    }
}
