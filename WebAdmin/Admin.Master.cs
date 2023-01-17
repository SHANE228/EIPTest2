using EIPTest.lib.AES;
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
            //抓取帳號
            string replace1 = MyAesCryptography.ReplaceSQLChar(AdminLogin.Text);

            //抓取密碼
            string replace2 = MyAesCryptography.ReplaceSQLChar(AdminPassword.Text);
            if (replace1=="SYS_ADMIN" && replace2=="ADMIN12345")
            {
                Session["UserID"] = this.AdminLogin.Text;
                Label1.Text = "歡迎~SYS_ADMIN";
                Label2.Visible = false;
                Label3.Visible = false;
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
            Label1.Text = "Login";
            Session.Remove("UserID");
            Response.Redirect("~/WebAdmin/AdminDefault.aspx");
        }


    }
}