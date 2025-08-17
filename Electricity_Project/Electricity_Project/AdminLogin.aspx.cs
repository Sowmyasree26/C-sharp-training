using System;
using System.Web;
using System.Web.UI;

namespace Electricity_Project
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            lblError.Text = "";

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            if (username == "admin" && password == "admin123")
            {

                Session["IsAuthenticated"] = true;
                Response.Redirect("BillEntry.aspx");
                Response.Redirect("BillEntry.aspx");
            }
            else
            {
                lblError.Text = "Invalid username or password.";
            }
        }
    }
}
