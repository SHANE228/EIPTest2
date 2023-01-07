using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EIPTest.WebAdmin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                Label1.Text = "歡迎~SYS_ADMIN";
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if(AdminLogin.Text=="SYS_ADMIN" && AdminPassword.Text=="ADMIN12345")
            {
                Session["UserID"] = this.AdminLogin.Text;
                Label1.Text = "歡迎~SYS_ADMIN";
                Label2.Visible = false;
                Label3.Visible = false;
                AdminLogin.Visible = false;
                AdminPassword.Visible = false;
                btnLogin.Visible = false;
            }
            else
            {
                Response.Write("<Script language='JavaScript'>alert('登入失敗');</Script>");
            }
        }

        protected void btnPassword_Click(object sender, EventArgs e)
        {
            AdminLogin.Text = "";
            AdminPassword.Text = "";
            Label2.Visible = true;
            Label3.Visible = true;
            AdminLogin.Visible = true;
            AdminPassword.Visible = true;
            btnLogin.Visible = true;
            Label1.Text = "Login";
            Session.Remove("UserID");
            Response.Redirect("~/WebAdmin/AdminDefault.aspx");
        }


    }
}