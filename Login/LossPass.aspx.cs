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
using System.Net.Mail;
using System.Net.Mime;
using System.Security.Cryptography.X509Certificates;

namespace EIPTest.Login
{
    public partial class LossPass : System.Web.UI.Page
    {
        public static string myKey = "1234567812345678";
        public static string myIV = "1234567812345678";
        DataBase db = new DataBase();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["empId"] != null)
            {
                Response.Redirect("~/Default.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //抓取EMAIL
            StringBuilder ssb = new StringBuilder();
            ssb.Append("SELECT EMP_EMAIL FROM SJ0007_LOGIN WHERE EMP_ID = '" + TextBox1.Text + "'");
            string to = db.GetOneColumnData(ssb.ToString());

            //檢查帳號是否有該帳號
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT COUNT(*) FROM SJ0007_LOGIN WHERE EMP_ID = '" + TextBox1.Text + "'");
            string gocl = db.GetOneColumnData(sb.ToString());
            int intGCL = Int32.Parse(gocl);
            if (intGCL != 0)
            {
                StringBuilder sba = new StringBuilder();
                sba.Append("SELECT EMP_PASSWORD FROM SJ0007_LOGIN WHERE EMP_ID= '" + TextBox1.Text + "'");
                string _password = db.GetOneColumnData(sba.ToString());
                string decryptText = MyAesCryptography.Decrypt(myKey, myIV, _password);

                try
                {
                    //寄信流程
                    MailMessage msg = new MailMessage();
                    msg.To.Add(new MailAddress(to));
                    msg.From = new MailAddress("shin-jan@outlook.com", "新展");
                    msg.Subject = "您的密碼";
                    msg.Body = "您的密碼 :" + decryptText;
                    msg.IsBodyHtml = true;

                    SmtpClient client = new SmtpClient();
                    client.UseDefaultCredentials = false;
                    client.Credentials = new System.Net.NetworkCredential("shin-jan@outlook.com", "yp6151111");
                    client.Port = 587;
                    client.Host = "smtp.office365.com";
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.EnableSsl = true;
                    client.Send(msg);
                    client.Dispose();
                    msg.Dispose();
                    Response.Write("<Script language='JavaScript'>alert('寄信成功');</Script>");
                }
                catch (Exception ex)
                {
                    Response.Write("<Script language='JavaScript'>alert('寄信失敗');</Script>");
                }
            }
            else
            {
                Response.Write("<Script language='JavaScript'>alert('不存在該帳號');</Script>");
            }
        }
    }
}