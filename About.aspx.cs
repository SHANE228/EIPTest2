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

namespace EIPTest
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["empId"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com", 587);
            //SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
            //MailMessage email = new MailMessage();
            //START
            //email.From = new MailAddress("mw108m10932024@gmail.com");
            //email.To.Add("ym3878394@gmail.com");
            //email.Subject = "測試";
            //email.Body = "TEST";
            //END
            //SmtpServer.Timeout = 5000;
            //SmtpServer.EnableSsl = true;
            //SmtpServer.UseDefaultCredentials = false;
            //SmtpServer.Credentials = new NetworkCredential("mw108m10932024@gmail.com", "pmusloaieyyqnhml");
            //SmtpServer.Send(email);


        }

    }
}