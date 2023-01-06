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

namespace EIPTest.WebAdmin.Commodity
{
    public partial class DeleteCommodity : System.Web.UI.Page
    {
        DataBase db = new DataBase();
        public ArrayList _arrayList = new ArrayList();
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            int rQuery = Int32.Parse(Request.QueryString["id"]);
            sb.Append("SELECT A.ITEM_ID, A.TYPE_ID, A.ITEM_TITLE, A.ITEM_PLACE, A.ITEM_PIC, A.ITEM_DESCR, A.ITEM_COUNT, A.ITEM_PRICE, A.ITEM_OPEN, A.ITEM_CLOSE, A.ITEM_STATUS, B.TYPE_NAME FROM ITEM_DETAIL A, ITEM_TYPE B WHERE A.TYPE_ID = B.TYPE_ID AND A.ITEM_ID ="+rQuery);
            _arrayList = db.QueryDB(sb.ToString());
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            StringBuilder sb1 = new StringBuilder();
            int rQuery = Int32.Parse(Request.QueryString["id"]);
            sb1.Append("UPDATE ITEM_DETAIL SET ITEM_STATUS= 'D' WHERE ITEM_ID=" + rQuery);
            db.UpdateDB(sb1.ToString());
            Response.Redirect("~/WebAdmin/Commodity/Commodity.aspx");
        }
    }
}