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
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT ITEM_ID, TYPE_ID, ITEM_TITLE, ITEM_PLACE, ITEM_PIC, ITEM_DESCR, ITEM_COUNT, ITEM_PRICE,ITEM_OPEN,ITEM_CLOSE,ITEM_STATUS, ITEM_VIEW_COUNT FROM ITEM_DETAIL");
            _arrayList = db.QueryDB(sb.ToString());
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/WebAdmin/Commodity/CreateCommodity.aspx");
        }
    }
}