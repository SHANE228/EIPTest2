using System;
using System.Globalization;
using System.Threading.Tasks;
using System.Security.Cryptography;
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
using EIPTest.lib.Org;


namespace EIPTest.WebAdmin.Bulletin
{
    public partial class CreateBulletin : System.Web.UI.Page
    {
        DataBase db = new DataBase();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("~/WebAdmin/AdminDefault.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string serial_ID = db.GetSequence("SJ0007_BULLETIN");
            StringBuilder sb = new StringBuilder();
            string result = System.Text.RegularExpressions.Regex.Replace(NO_OPEN.Text, "[-]", "");
            string result2 = System.Text.RegularExpressions.Regex.Replace(NO_CLOSE.Text, "[-]", "");
            sb.Append("INSERT INTO NOTICE_DETAIL (NOTICE_ID, NOTICE_TOPIC, NOTICE_CONTENT, NOTICE_OPEN, NOTICE_CLOSE, NOTICE_STATUS, CREATE_TIME, WHO_CREATE, MODIFY_TIME, WHO_MODIFY)");
            sb.Append("VALUES (" + MyAesCryptography.ReplaceSQLChar(serial_ID) + ",'" + MyAesCryptography.ReplaceSQLChar(NO_TOPIC.Text) + "','" + MyAesCryptography.ReplaceSQLChar(NO_CONTENT.Text) + "'," + result + "," + result2 + ",'" + NO_STATUS.Text + "'," + "SYSDATE, 'SYS_ADMIN', SYSDATE,'SYS_ADMIN')");
            db.UpdateDB(sb.ToString());
            Response.Redirect("~/WebAdmin/Bulletin/Bulletin.aspx");
        }
    }
}