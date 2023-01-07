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
    public partial class LoginPass : System.Web.UI.Page
    {
        DataBase db = new DataBase();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["empId"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            EmpObject empBasic = new EmpObject(Session["empId"].ToString());
            EMP_Name.Text = empBasic.empName;
            EMP_Mail.Text = empBasic.empEmail;
            EMP_Phone.Text = empBasic.empPhone;
            EMP_Place.Text = empBasic.empPlace;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login/LoginData.aspx");
        }

        protected void btnUdatePass_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login/LoginPassUpdate.aspx");
        }
    }
}