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
using Oracle.ManagedDataAccess.Client;
using System.Configuration;

namespace EIPTest
{
    public partial class SiteMaster : MasterPage
    {
        public DataBase db = new DataBase();
        public static string myKey = "1234567812345678";
        public static string myIV = "1234567812345678";
        public ArrayList punchList;
        private OracleConnection Conn;
        private OracleCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["empId"] != null)
            {
                EmpObject empBasic = new EmpObject(Session["empId"].ToString());
                Label1.Text = "歡迎登入" + "<br>" + " 帳號:" + empBasic.empId + "<br>" + "姓名:" + empBasic.empName;
            }
        }

        protected void btLogin_Click(object sender, EventArgs e)
        {



            string login = getLogin();
            string password = getPassword();
            string decryptText = MyAesCryptography.Decrypt(myKey, myIV, password);

            //辨識帳號密碼
            if (AdminLogin.Text == login && AdminPassword.Text == decryptText)
            {
                Session["empId"] = login;
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                Label1.Text = "帳號或密碼錯誤";
            }

            /*
            抓取帳號
            string replace1 = MyAesCryptography.ReplaceSQLChar(AdminLogin.Text);
            抓取密碼
            string replace2 = MyAesCryptography.ReplaceSQLChar(AdminPassword.Text);
            string password = MyAesCryptography.Encrypt(myKey, myIV, replace2);
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT EMP_PASSWORD FROM SJ0007_LOGIN WHERE EMP_PASSWORD= '" + password + "'");
            string _password = db.GetOneColumnData(sb.ToString());
            //解碼
            string decryptText = MyAesCryptography.Decrypt(myKey, myIV, _password);
            //抓取帳號
            StringBuilder apSb = new StringBuilder();
            apSb.Append("SELECT EMP_ID FROM SJ0007_LOGIN WHERE EMP_ID= '" + replace1 + "'");
            string _account = db.GetOneColumnData(apSb.ToString());

            //辨識帳號密碼
            if (replace1 == _account && replace2 == decryptText)
            {
                Session["empId"] = _account;
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                Label1.Text = "帳號或密碼錯誤";
            }
            */
        }

        protected void btPassword_Click(object sender, EventArgs e)
        {
            //label1.Text = "";
            Session.Remove("empId");
            Response.Redirect("~/Default.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login/LoginAdd.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login/LossPass.aspx");
        }



        private void open()
        {
            Conn = new OracleConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
            Conn.Open();
            cmd = new OracleCommand();
            cmd.Connection = Conn;


        }


        private void close()
        {
            if (Conn.State != ConnectionState.Closed)
            {
                cmd.Dispose();
                Conn.Close();
                Conn.Dispose();
            }
        }

        public string getLogin()
        {
            string value1 = "";
            open();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT EMP_ID FROM SJ0007_LOGIN WHERE EMP_ID= :AdminLogin";
            cmd.Parameters.Add(new OracleParameter(":AdminLogin", AdminLogin.Text));
            OracleDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                value1 = Convert.ToString(dr.GetValue(0));
            }
            close();
            return value1;
        }

        public string getPassword()
        {
            string value2 = "";
            open();
            string pass = MyAesCryptography.Encrypt(myKey, myIV, AdminPassword.Text);
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT EMP_PASSWORD FROM SJ0007_LOGIN WHERE EMP_PASSWORD= :password";
            cmd.Parameters.Add(new OracleParameter(":password", pass));
            OracleDataReader dra = cmd.ExecuteReader();
            if (dra.Read())
            {
                value2 = Convert.ToString(dra.GetValue(0));
            }
            close();
            return value2;
        }
    }
}