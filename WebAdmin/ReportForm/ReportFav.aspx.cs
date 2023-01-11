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

namespace EIPTest.WebAdmin.ReportForm
{
    public partial class ReportFav : System.Web.UI.Page
    {
        public DataBase db = new DataBase();
        public ArrayList _arrayList = new ArrayList();
        public ArrayList _arrayList1 = new ArrayList();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("~/WebAdmin/AdminDefault.aspx");
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT A.ITEM_ID, B.TYPE_NAME, A.ITEM_OPEN, A.ITEM_CLOSE, A.ITEM_VIEW_COUNT FROM ITEM_DETAIL A, ITEM_TYPE B  WHERE A.TYPE_ID = B.TYPE_ID AND NOT A.ITEM_STATUS ='D'");
            _arrayList = db.QueryDB(sb.ToString());

            StringBuilder sb1 = new StringBuilder();
            sb1.Append("SELECT A.ITEM_ID, B.TYPE_NAME, A.ITEM_OPEN, A.ITEM_CLOSE, A.ITEM_VIEW_COUNT FROM ITEM_DETAIL A, ITEM_TYPE B  WHERE A.TYPE_ID = B.TYPE_ID AND A.ITEM_STATUS ='D'");
            _arrayList1 = db.QueryDB(sb1.ToString());
        }
    }
}