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

namespace EIPTest
{
    public partial class SiteMaster : MasterPage
    {
        DataBase db = new DataBase();
        protected void Page_Init(object sender, EventArgs e)
        {
            if(Session["empId"] != null)
            {
                EmpObject empBasic = new EmpObject(Session["empId"].ToString());
                labLogin.Text = "歡迎登入"+ "\r\n" +  " 帳號:" + empBasic.empId;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            labLogin.Text = "";
            Session.Remove("empId");
            Response.Redirect("~/Default.aspx");
        }
    }
}