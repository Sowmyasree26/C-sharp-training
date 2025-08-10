using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP_1
{
    public partial class Form1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txt.Text = "Hello";
            Response.Write(txt.Text);

        }

        protected void txt_TextChanged(object sender, EventArgs e)
        {
            txt.Text = "HEllo";
        }
    }
}