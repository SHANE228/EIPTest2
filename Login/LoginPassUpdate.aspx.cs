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
    public partial class LoginPassUpdate : System.Web.UI.Page
    {
        public static string myKey = "1234567812345678";
        public static string myIV = "1234567812345678";
        DataBase db = new DataBase();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["empId"] == null)
            {
                Response.Redirect("~/Login/Login.aspx");
            }
            EmpObject empBasic = new EmpObject(Session["empId"].ToString());
            Label1.Text = empBasic.empId;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            StringBuilder sba = new StringBuilder();
            StringBuilder sb = new StringBuilder();
            EmpObject empBasic = new EmpObject(Session["empId"].ToString());
            string base64NID = MyAesCryptography.Encrypt(myKey, myIV, TextBox2.Text);
            string base64NID2 = MyAesCryptography.Encrypt(myKey, myIV, TextBox3.Text);
            sba.Append("SELECT EMP_PASSWORD FROM SJ0007_LOGIN WHERE EMP_PASSWORD = '" + base64NID + "'");
            string passNID = db.GetOneColumnData(sba.ToString());
            string ase64NID = MyAesCryptography.Decrypt(myKey, myIV, passNID);


            if (base64NID == base64NID2)
            {
                if (TextBox2.Text == ase64NID)
                {
                    Label2.Text = "密碼相同";
                }
                else
                {
                    sb.Append("UPDATE SJ0007_LOGIN SET EMP_PASSWORD ='" + base64NID + "'WHERE EMP_ID='" + empBasic.empId + "'");
                    db.UpdateDB(sb.ToString());

                }

            }
            else
            {
                Label2.Text = "請填相同密碼";
            }
            Response.Write("<Script language='JavaScript'>alert('已成功完成密碼修改');</Script>");
        }
    }
}