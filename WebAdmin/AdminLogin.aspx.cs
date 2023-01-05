using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EIPTest.WebAdmin
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(TextBox1.Text=="SYS_ADMIN" && TextBox2.Text == "ADMIN12345")
            {
                Response.Redirect("~/WebAdmin/AdminDefault.aspx");
            }
            else
            {
                Response.Write("<Script language='JavaScript'>alert('登入失敗');</Script>");
            }
        }
    }
}