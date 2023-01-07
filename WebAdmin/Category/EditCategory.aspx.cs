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
    public partial class EditCategory : System.Web.UI.Page
    {
        DataBase db = new DataBase();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("~/WebAdmin/AdminDefault.aspx");
            }
            try
            {
                if (!IsPostBack)
                {
                    StringBuilder sb1 = new StringBuilder();
                    int rQuery = Int32.Parse(Request.QueryString["id"]);
                    sb1.Append("SELECT TYPE_UPPER FROM ITEM_TYPE WHERE TYPE_ID=" + rQuery);
                    string upper = db.GetOneColumnData(sb1.ToString());

                    StringBuilder sb2 = new StringBuilder();
                    sb2.Append("SELECT TYPE_CODE FROM ITEM_TYPE WHERE TYPE_ID=" + rQuery);
                    string code = db.GetOneColumnData(sb2.ToString());

                    StringBuilder sb3 = new StringBuilder();
                    sb3.Append("SELECT TYPE_NAME FROM ITEM_TYPE WHERE TYPE_ID=" + rQuery);
                    string name = db.GetOneColumnData(sb3.ToString());

                    StringBuilder sb4 = new StringBuilder();
                    sb4.Append("SELECT TYPE_PS FROM ITEM_TYPE WHERE TYPE_ID=" + rQuery);
                    string ps = db.GetOneColumnData(sb4.ToString());
                    TextBox1.Text = upper;
                    TextBox2.Text = code;
                    TextBox3.Text = name;
                    TextBox4.Text = ps;
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("~/WebAdmin/Category/CommodityCategory.aspx");
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int rQuery = Int32.Parse(Request.QueryString["id"]);
            StringBuilder sb5 = new StringBuilder();
            sb5.Append("SELECT TYPE_ID FROM ITEM_TYPE WHERE TYPE_ID=" + rQuery);
            string id = db.GetOneColumnData(sb5.ToString());

            if (id == "1")
            {

                StringBuilder sb = new StringBuilder();
                sb.Append("UPDATE ITEM_TYPE SET TYPE_UPPER = NULL , TYPE_CODE ='" + TextBox2.Text + "', TYPE_NAME ='" + TextBox3.Text + "', TYPE_PS = '" + TextBox4.Text + "',MODIFY_TIME= SYSDATE WHERE TYPE_ID =" + rQuery);
                db.UpdateDB(sb.ToString());
                Response.Redirect("~/WebAdmin/Category/CommodityCategory.aspx");
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("UPDATE ITEM_TYPE SET TYPE_UPPER =" + TextBox1.Text + "," + "TYPE_CODE ='" + TextBox2.Text + "', TYPE_NAME ='" + TextBox3.Text + "', TYPE_PS = '" + TextBox4.Text + "',MODIFY_TIME= SYSDATE WHERE TYPE_ID =" + rQuery);
                db.UpdateDB(sb.ToString());
                Response.Redirect("~/WebAdmin/Category/CommodityCategory.aspx");
            }


        }
    }
}