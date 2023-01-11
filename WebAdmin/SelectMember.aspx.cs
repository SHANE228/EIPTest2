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
namespace EIPTest.WebAdmin
{
    public partial class SelectMember : System.Web.UI.Page
    {
        public ArrayList _arrayList = new ArrayList();
        DataBase db = new DataBase();
        public string myKey = "1234567812345678";
        public string myIV = "1234567812345678";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("~/WebAdmin/AdminDefault.aspx");
            }
        }
    

        protected void Button1_Click(object sender, EventArgs e)
        {
            string name = MyAesCryptography.ReplaceSQLChar(TextBox1.Text);
            try
            {
                StringBuilder sb1 = new StringBuilder();
                sb1.Append("SELECT NATIONAL_ID, EMP_ID, EMP_NAME, EMP_EMAIL, EMP_SEX, EMP_PHONE, EMP_PLACE, EMP_BIRTHDAY, CREATE_TIME, MODIFY_TIME FROM SJ0007_LOGIN WHERE EMP_NAME LIKE '%" + name + "%'");
                _arrayList = db.QueryDB(sb1.ToString());
            }
            catch (Exception ex)
            {
                Response.Write("<Script language='JavaScript'>alert('輸入錯誤');</Script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                string name = MyAesCryptography.ReplaceSQLChar(TextBox2.Text);
                StringBuilder sb2 = new StringBuilder();
                string pass = MyAesCryptography.Encrypt(myKey, myIV, name);
                sb2.Append("SELECT NATIONAL_ID, EMP_ID, EMP_NAME, EMP_EMAIL, EMP_SEX, EMP_PHONE, EMP_PLACE, EMP_BIRTHDAY, CREATE_TIME, MODIFY_TIME FROM SJ0007_LOGIN WHERE NATIONAL_ID ='" + pass + "'");
                _arrayList = db.QueryDB(sb2.ToString());
            }
            catch (Exception ex)
            {
                Response.Write("<Script language='JavaScript'>alert('輸入錯誤');</Script>");
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string year = Request.Form["year"];
            string month = Request.Form["month"];
            string day = Request.Form["day"];

            //如果日不為空值,9以下的數字前面補0
            if (day != "")
            {
                int intDay = Int32.Parse(day);
                if (intDay <= 9)
                {
                    day = intDay.ToString("00");
                }
            }
            try
            {
                StringBuilder sb3 = new StringBuilder();
                sb3.Append("SELECT NATIONAL_ID, EMP_ID, EMP_NAME, EMP_EMAIL, EMP_SEX, EMP_PHONE, EMP_PLACE, EMP_BIRTHDAY, CREATE_TIME, MODIFY_TIME ");
                sb3.Append("FROM SJ0007_LOGIN WHERE EMP_BIRTHDAY LIKE '%" + year + "%' AND EMP_BIRTHDAY LIKE '%" + month + "%' AND EMP_BIRTHDAY LIKE '%" + day + "%'");
                _arrayList = db.QueryDB(sb3.ToString());
            }
            catch
            {
                Response.Write("<Script language='JavaScript'>alert('輸入錯誤');</Script>");
            }

        }
    }
}