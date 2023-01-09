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

namespace EIPTest.ProductBrowse
{
    public partial class ProductContent : System.Web.UI.Page
    {
        DataBase db = new DataBase();
        public ArrayList _arrayList = new ArrayList();
        protected void Page_Load(object sender, EventArgs e)
        {
            int rQuery = Int32.Parse(Request.QueryString["id"]);
            StringBuilder sba = new StringBuilder();
            sba.Append("SELECT ITEM_VIEW_COUNT FROM ITEM_DETAIL WHERE ITEM_ID= " + rQuery);
            string ivc = db.GetOneColumnData(sba.ToString());
            int intIvc = Int32.Parse(ivc)+1;
            StringBuilder sbc = new StringBuilder();
            sbc.Append("UPDATE ITEM_DETAIL SET ITEM_VIEW_COUNT=" + intIvc + " WHERE ITEM_ID= " + rQuery);
            db.QueryDB(sbc.ToString());
            Label1.Text = intIvc.ToString();
            if (Button1.Enabled == true)
            {
                Button2.Enabled = false;
                Button2.Visible = false;
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT A.ITEM_ID, A.TYPE_ID, A.ITEM_TITLE, A.ITEM_PIC, A.ITEM_DESCR, A.ITEM_COUNT, A.ITEM_PRICE, A.ITEM_OPEN, A.ITEM_CLOSE, A.ITEM_STATUS, B.TYPE_NAME FROM ITEM_DETAIL A,ITEM_TYPE B WHERE A.TYPE_ID = B.TYPE_ID AND NOT A.ITEM_STATUS ='D' AND NOT A.ITEM_STATUS ='N' AND A.ITEM_ID="+ rQuery);
            _arrayList = db.QueryDB(sb.ToString());
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            EmpObject empBasic = new EmpObject(Session["empId"].ToString());
            string serial_ID = db.GetSequence("SJ0007_FAV");
            StringBuilder sb1 = new StringBuilder();
            sb1.Append("INSERT INTO MEMBER_FAVORITE ( FAV_ID, MEMBER_ID, ITEM_ID, FAV_STATUS, CREATE_TIME, WHO_CREATE, MODIFY_TIME, WHO_MODIFY, DELETE_TIME )");
            sb1.Append("VALUES ("+serial_ID +","+)")
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }
    }
}