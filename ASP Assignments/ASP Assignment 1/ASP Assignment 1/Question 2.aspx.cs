using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP_Assignment_1
{
    public partial class Question_2 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                imgProduct.Visible = false;
                lblPrice.Visible = false;
            }
        }

        protected void ddlProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            imgProduct.Visible = false;
            lblPrice.Visible = false;

            switch (ddlProducts.SelectedValue)
            {
                case "1":
                    imgProduct.ImageUrl = "images/chocolates.jpg";
                    lblPrice.Text = "Price: $500";
                    break;
                case "2":
                    imgProduct.ImageUrl = "images/cookies.jpg";
                    lblPrice.Text = "Price: $250";
                    break;
                case "3":
                    imgProduct.ImageUrl = "images/toys.jpg";
                    lblPrice.Text = "Price: $600";
                    break;
                case "4":
                    imgProduct.ImageUrl = "images/download.jpg";
                    lblPrice.Text = "Price: $250";
                    break;
                default:
                    return;
            }
            imgProduct.Visible = true;
        }

        protected void btnGetPrice_Click(object sender, EventArgs e)
        {
            lblPrice.Visible = true;
        }
    }
}