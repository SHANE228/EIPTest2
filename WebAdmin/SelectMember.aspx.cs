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
           
        }
    

        protected void Button1_Click(object sender, EventArgs e)
        {
            StringBuilder sb1 = new StringBuilder();
            sb1.Append("SELECT NATIONAL_ID, EMP_ID, EMP_NAME, EMP_EMAIL, EMP_SEX, EMP_PHONE, EMP_PLACE, EMP_BIRTHDAY FROM SJ0007_LOGIN WHERE EMP_NAME LIKE '%" + TextBox1.Text+"%'");
            _arrayList = db.QueryDB(sb1.ToString());
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            StringBuilder sb2 = new StringBuilder();
            string pass = MyAesCryptography.Encrypt(myKey, myIV, TextBox2.Text);
            sb2.Append("SELECT NATIONAL_ID, EMP_ID, EMP_NAME, EMP_EMAIL, EMP_SEX, EMP_PHONE, EMP_PLACE, EMP_BIRTHDAY FROM SJ0007_LOGIN WHERE NATIONAL_ID ='" + pass + "'");
            _arrayList = db.QueryDB(sb2.ToString());
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            
            int intGetMonth = Int32.Parse(Request["month"]);
            int intGetDay = Int32.Parse(Request["day"]);
            int intGetYear = Int32.Parse(Request["year"])+1909;

            DateTime dt = new DateTime(intGetYear, intGetMonth, intGetDay);
            string toDt = dt.ToString("yyyy/MM/dd");
            StringBuilder sb3 = new StringBuilder();
            sb3.Append("SELECT NATIONAL_ID, EMP_ID, EMP_NAME, EMP_EMAIL, EMP_SEX, EMP_PHONE, EMP_PLACE, EMP_BIRTHDAY ");
            sb3.Append("FROM SJ0007_LOGIN WHERE EMP_BIRTHDAY = TO_DATE('" + toDt + "'," + "'yyyy-MM-dd')");
            _arrayList = db.QueryDB(sb3.ToString());
        }
    }
}