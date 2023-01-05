using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using EIPTest.lib.Connect;
using EIPTest.lib.AES;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Sockets;
using System.Globalization;
using System.Threading.Tasks;
using System.Security.Cryptography;
using EIPTest.lib.Org;

namespace EIPTest.Login
{
    public partial class Login : System.Web.UI.Page
    {
        public static string myKey = "1234567812345678";
        public static string myIV = "1234567812345678";
        DataBase db = new DataBase();
        public ArrayList punchList;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login/LoginAdd.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT EMP_PASSWORD FROM SJ0007_LOGIN WHERE EMP_ID= '" + TextBox1.Text + "'");
            string _password = db.GetOneColumnData(sb.ToString());
            string decryptText = MyAesCryptography.Decrypt(myKey, myIV, _password);
            StringBuilder apSb = new StringBuilder();
            apSb.Append("SELECT EMP_ID FROM SJ0007_LOGIN WHERE EMP_ID= '" + TextBox1.Text + "'");
            string _account = db.GetOneColumnData(apSb.ToString());

            if (TextBox1.Text == _account && TextBox2.Text == decryptText)
            {
                Session["empId"] = _account;
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                Label1.Text = "帳號或密碼錯誤";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login/LossPass.aspx");
        }
    }
}