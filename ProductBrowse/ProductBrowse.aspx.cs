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
    public partial class ProductBrowse : System.Web.UI.Page
    {
        DataBase db = new DataBase();
        public ArrayList _arrayList;
        public ArrayList _arrayList2;
        protected void Page_Init(object sender, EventArgs e)
        {

            StringBuilder sb = new StringBuilder();
            StringBuilder sb1 = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();

            ArrayList rrayList = new ArrayList();
            sb.Append("SELECT TYPE_ID, TYPE_NAME FROM ITEM_TYPE WHERE TYPE_LEVEL = 1");
            rrayList = db.QueryDB(sb.ToString());
            if (rrayList.Count > 0)
            {
                DropDownList1.Items.Add("");
                foreach (Hashtable ht in rrayList)
                {
                    DropDownList1.Items.Add(ht["TYPE_NAME"].ToString());
                }
                //Panel1.Controls.Add(DropDownList1);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
                StringBuilder sba = new StringBuilder();
                sba.Append("SELECT ITEM_ID, ITEM_PIC, ITEM_TITLE FROM ITEM_DETAIL WHERE ITEM_STATUS ='Y'");
                _arrayList = db.QueryDB(sba.ToString());
            //}
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            StringBuilder sb3 = new StringBuilder();
            StringBuilder sb4 = new StringBuilder();

            ArrayList rrayList2 = new ArrayList();
            try
            {
                 sb3.Append("SELECT TYPE_ID FROM ITEM_TYPE WHERE TYPE_NAME ='" + DropDownList1.Text + "'");
            string BData = db.GetOneColumnData(sb3.ToString());
            int intBData = Int32.Parse(BData);
            sb4.Append("SELECT TYPE_NAME FROM ITEM_TYPE WHERE TYPE_UPPER=" + BData);
            rrayList2 = db.QueryDB(sb4.ToString());
            if (rrayList2.Count > 0)
            {
                DropDownList2.Items.Clear();
                DropDownList1.Items.Add("");
                foreach (Hashtable ht2 in rrayList2)
                {
                    DropDownList2.Items.Add(ht2["TYPE_NAME"].ToString());
                }

            }
            }
            catch (Exception ex)
            {
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(DropDownList2.Text == "" && TextBox1.Text=="")
            {
                StringBuilder sb5 = new StringBuilder();
                sb5.Append("SELECT ITEM_ID, ITEM_PIC, ITEM_TITLE FROM ITEM_DETAIL WHERE ITEM_STATUS ='Y' AND ITEM_PLACE ='" + DropDownList3.Text +"'");
                Response.Write(sb5.ToString());
                _arrayList = db.QueryDB(sb5.ToString());

            }
            else if (DropDownList3.Text=="" && TextBox1.Text == "")
            {
                StringBuilder ssb = new StringBuilder();
                ssb.Append("SELECT TYPE_ID FROM ITEM_TYPE WHERE TYPE_NAME='" + DropDownList2.Text + "'");
                string typeID = db.GetOneColumnData(ssb.ToString());
                //int intTypeID = Int32.Parse(typeID);
                StringBuilder sb5 = new StringBuilder();
                sb5.Append("SELECT ITEM_ID, ITEM_PIC, ITEM_TITLE FROM ITEM_DETAIL WHERE ITEM_STATUS ='Y' AND TYPE_ID=" + typeID);
                _arrayList = db.QueryDB(sb5.ToString());
                Response.Write(sb5.ToString());
            }
            else if(TextBox1.Text=="")
            {
                StringBuilder ssb = new StringBuilder();
                ssb.Append("SELECT TYPE_ID FROM ITEM_TYPE WHERE TYPE_NAME='" + DropDownList2.Text + "'");
                string typeID = db.GetOneColumnData(ssb.ToString());
                //int intTypeID = Int32.Parse(typeID);
                StringBuilder sb5 = new StringBuilder();
                sb5.Append("SELECT ITEM_ID, ITEM_PIC, ITEM_TITLE FROM ITEM_DETAIL WHERE ITEM_STATUS ='Y' AND ITEM_PLACE ='" + DropDownList3.Text + "' AND TYPE_ID=" + typeID );
                _arrayList = db.QueryDB(sb5.ToString());
                Response.Write(sb5.ToString());
            }
            else if (DropDownList2.Text=="")
            {
                StringBuilder sb5 = new StringBuilder();
                sb5.Append("SELECT ITEM_ID, ITEM_PIC, ITEM_TITLE FROM ITEM_DETAIL WHERE ITEM_STATUS ='Y' AND ITEM_TITLE LIKE '%" + TextBox1.Text + "%' AND ITEM_PLACE ='" + DropDownList3.Text + "'");
                Response.Write(sb5.ToString());
                _arrayList = db.QueryDB(sb5.ToString());
            }
            else if (DropDownList3.Text == "")
            {
                StringBuilder ssb = new StringBuilder();
                ssb.Append("SELECT TYPE_ID FROM ITEM_TYPE WHERE TYPE_NAME='" + DropDownList2.Text + "'");
                string typeID = db.GetOneColumnData(ssb.ToString());
                //int intTypeID = Int32.Parse(typeID);
                StringBuilder sb5 = new StringBuilder();
                sb5.Append("SELECT ITEM_ID, ITEM_PIC, ITEM_TITLE FROM ITEM_DETAIL WHERE ITEM_STATUS ='Y' AND ITEM_TITLE LIKE '%" + TextBox1.Text + "%' AND TYPE_ID=" + typeID);
                _arrayList = db.QueryDB(sb5.ToString());
                Response.Write(sb5.ToString());
            }
            else
            {
                StringBuilder ssb = new StringBuilder();
                ssb.Append("SELECT TYPE_ID FROM ITEM_TYPE WHERE TYPE_NAME='" + DropDownList2.Text + "'");
                string typeID = db.GetOneColumnData(ssb.ToString());
                //int intTypeID = Int32.Parse(typeID);
                StringBuilder sb5 = new StringBuilder();
                sb5.Append("SELECT ITEM_ID, ITEM_PIC, ITEM_TITLE FROM ITEM_DETAIL WHERE ITEM_STATUS ='Y' AND (ITEM_TITLE LIKE '%" + TextBox1.Text + "%' AND ITEM_PLACE ='" + DropDownList3.Text + "' AND TYPE_ID=" + typeID + ")");
                _arrayList = db.QueryDB(sb5.ToString());
                Response.Write(sb5.ToString());
            }
        }
    }
}