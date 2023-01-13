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

namespace EIPTest
{
    public partial class NoticeContent : System.Web.UI.Page
    {
        public DataBase db = new DataBase();
        public ArrayList _arrayList = new ArrayList();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                int rQuery = Int32.Parse(Request.QueryString["id"]);
                sb.Append("SELECT NOTICE_TOPIC, NOTICE_OPEN, NOTICE_CONTENT FROM NOTICE_DETAIL WHERE NOTICE_ID =" + rQuery);
                _arrayList = db.QueryDB(sb.ToString());
            }
            catch (Exception)
            {
            }
        }
    }
}