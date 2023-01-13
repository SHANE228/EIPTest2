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

namespace EIPTest.WebAdmin
{
    public partial class CommodityCategory : System.Web.UI.Page
    {
        DataBase db = new DataBase();
        public ArrayList _arrayList = new ArrayList();
        
        protected void Page_Init(object sender, EventArgs e)
        {

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("~/WebAdmin/AdminDefault.aspx");
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT TYPE_ID, TYPE_LEVEL, TYPE_UPPER, TYPE_CODE, TYPE_STATUS, TYPE_NAME, TYPE_PS FROM ITEM_TYPE ORDER BY TYPE_ID ASC ");
            _arrayList = db.QueryDB(sb.ToString());
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/WebAdmin/Category/CreateCategory.aspx");
        }

    }
}