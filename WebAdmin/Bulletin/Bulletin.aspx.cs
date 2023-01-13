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
    public partial class Bulletinaspx : System.Web.UI.Page
    {
        DataBase db = new DataBase();
        public ArrayList _arrayList = new ArrayList();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("~/WebAdmin/AdminDefault.aspx");
            }
            //排除公告狀態為刪除'D'
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT NOTICE_ID, NOTICE_TOPIC, NOTICE_CONTENT, NOTICE_OPEN, NOTICE_CLOSE, NOTICE_STATUS, CREATE_TIME, MODIFY_TIME FROM NOTICE_DETAIL WHERE NOT NOTICE_STATUS ='D' ORDER BY NOTICE_ID ASC");
            _arrayList = db.QueryDB(sb.ToString());
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/WebAdmin/Bulletin/CreateBulletin.aspx");
        }
    }
}