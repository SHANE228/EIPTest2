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
    public partial class LoginData : System.Web.UI.Page
    {
        DataBase db = new DataBase();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["empId"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (!IsPostBack)
            {
                //資料庫抓取個人資料
                EmpObject empBasic = new EmpObject(Session["empId"].ToString());
                EMP_Name.Text = empBasic.empName;
                EMP_Mail.Text = empBasic.empEmail;
                EMP_Phone.Text = empBasic.empPhone;
                DropDownList1.Text = empBasic.empPlace;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //更改個人檔案
            string name = MyAesCryptography.ReplaceSQLChar(EMP_Name.Text);
            EmpObject empBasics = new EmpObject(Session["empId"].ToString());
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE SJ0007_LOGIN SET EMP_NAME ='" + name + "', EMP_EMAIL = '" + EMP_Mail.Text + "', EMP_PHONE = '" + EMP_Phone.Text + "', EMP_PLACE = '" + DropDownList1.Text + "', MODIFY_TIME = SYSDATE ");
            sb.Append("WHERE EMP_ID = '" + empBasics.empId + "'");
            db.UpdateDB(sb.ToString());
            Response.Write(sb.ToString());
            Response.Redirect("~/Login/LoginPass.aspx");
        }
    }
}