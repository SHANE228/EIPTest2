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
namespace EIPTest.Login
{
    public partial class LoginAdd : System.Web.UI.Page
    {

        DataBase db = new DataBase();
        public ArrayList punchList;
        public string myKey = "1234567812345678";
        public string myIV = "1234567812345678";
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //身分證加密
            StringBuilder sba = new StringBuilder();
            string _base64NID = MyAesCryptography.Encrypt(myKey, myIV, National_ID.Text);
            sba.Append("SELECT NATIONAL_ID FROM SJ0007_LOGIN WHERE NATIONAL_ID = '" + _base64NID + "'");
            string passNID = db.GetOneColumnData(sba.ToString());

            //帳號是否重複
            StringBuilder ssb = new StringBuilder();
            ssb.Append("SELECT COUNT(*) FROM SJ0007_LOGIN WHERE EMP_ID = '" + EMP_ID.Text + "'");
            string gocl = db.GetOneColumnData(ssb.ToString());
            int intGCL = Int32.Parse(gocl);
            string serial_ID = db.GetSequence("SJ0007_SERIAL");
            string result = System.Text.RegularExpressions.Regex.Replace(EMP_Birthday.Text, "[-]", "");
            //檢核身分證或帳號是否重複
            if (intGCL != 0 && _base64NID == passNID)
            {
                Label1.Text = "帳號與身分證重複";
            }
            else if (intGCL != 0)
            {
                Label1.Text = "帳號重複";
            }
            else if (_base64NID == passNID)
            {
                Label1.Text = "身分證重複";
            }
            else
            {
                //不重複執行以下程式碼
                string msg = "";
                if (RadioButton1.Checked)
                {
                    msg = RadioButton1.Text;
                    if (msg == "男")
                    {
                        int intMsg = 1;

                        //身分證與密碼加密回傳到資料庫
                        
                        string base64String = MyAesCryptography.Encrypt(myKey, myIV, EMP_Password.Text);
                        string base64NID = MyAesCryptography.Encrypt(myKey, myIV, National_ID.Text);
                        StringBuilder sb = new StringBuilder();
                        sb.Append("INSERT INTO SJ0007_LOGIN (SERIAL_ID, NATIONAL_ID, EMP_ID, EMP_NAME, EMP_PASSWORD, EMP_EMAIL, EMP_SEX, EMP_PHONE, EMP_PLACE, EMP_BIRTHDAY, CREATE_TIME, MODIFY_TIME)");
                        sb.Append("VALUES(" + MyAesCryptography.ReplaceSQLChar(serial_ID) + ",'" + MyAesCryptography.ReplaceSQLChar(base64NID) + "', '" + MyAesCryptography.ReplaceSQLChar(EMP_ID.Text) + "', '" + MyAesCryptography.ReplaceSQLChar(EMP_Name.Text) + "', '" + MyAesCryptography.ReplaceSQLChar(base64String) + "','" + MyAesCryptography.ReplaceSQLChar(EMP_Mail.Text) + "', " + intMsg + ", '" + MyAesCryptography.ReplaceSQLChar(EMP_Phone.Text) + "', '" + DropDownList1.Text + "', " + result + ", " + "SYSDATE" + ", " + "SYSDATE" + ")");

                        db.UpdateDB(sb.ToString());
                        //Response.Write(sb.ToString());
                        Response.Redirect("~/Login/Login.aspx");
                    }
                }
                else
                {
                    msg = RadioButton2.Text;
                    if (msg == "女")
                    {
                        int intMsg = 2;
                        //身分證與密碼加密回傳到資料庫
                        string base64String = MyAesCryptography.Encrypt(myKey, myIV, EMP_Password.Text);
                        string base64NID = MyAesCryptography.Encrypt(myKey, myIV, National_ID.Text);
                        StringBuilder sb = new StringBuilder();
                        sb.Append("INSERT INTO SJ0007_LOGIN (SERIAL_ID, NATIONAL_ID, EMP_ID, EMP_NAME, EMP_PASSWORD, EMP_EMAIL, EMP_SEX, EMP_PHONE, EMP_PLACE, EMP_BIRTHDAY, CREATE_TIME, MODIFY_TIME)");
                        sb.Append("VALUES(" + MyAesCryptography.ReplaceSQLChar(serial_ID) + ",'" + MyAesCryptography.ReplaceSQLChar(base64NID) + "', '" + MyAesCryptography.ReplaceSQLChar(EMP_ID.Text) + "', '" + MyAesCryptography.ReplaceSQLChar(EMP_Name.Text) + "', '" + MyAesCryptography.ReplaceSQLChar(base64String) + "','" + MyAesCryptography.ReplaceSQLChar(EMP_Mail.Text) + "', " + intMsg + ", '" + MyAesCryptography.ReplaceSQLChar(EMP_Phone.Text) + "', '" + DropDownList1.Text + "', " + result + ", " + "SYSDATE" + ", " + "SYSDATE" + ")");
                        db.UpdateDB(sb.ToString());
                        //Response.Write(sb.ToString());
                        Response.Redirect("~/Default.aspx");
                    }
                }
            }
        }
    }
}