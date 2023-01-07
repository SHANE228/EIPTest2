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
    public partial class Commodity : System.Web.UI.Page
    {
        DataBase db = new DataBase();
        public ArrayList _arrayList = new ArrayList();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("~/WebAdmin/AdminDefault.aspx");
            }
            //SELECT 商品管理內容，且排除刪除狀態
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT A.ITEM_ID, A.TYPE_ID, A.ITEM_TITLE, A.ITEM_PLACE, A.ITEM_PIC, A.ITEM_DESCR, A.ITEM_COUNT, A.ITEM_PRICE, A.ITEM_OPEN, A.ITEM_CLOSE, A.ITEM_STATUS, A.CREATE_TIME , A.MODIFY_TIME, B.TYPE_NAME FROM ITEM_DETAIL A,ITEM_TYPE B WHERE A.TYPE_ID = B.TYPE_ID AND NOT A.ITEM_STATUS ='D'");
            _arrayList = db.QueryDB(sb.ToString());
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/WebAdmin/Commodity/CreateCommodity.aspx");
        }
    }
}