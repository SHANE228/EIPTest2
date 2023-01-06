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
    public partial class EditCommodity : System.Web.UI.Page
    {
        DataBase db = new DataBase();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                StringBuilder sb1 = new StringBuilder();
                int rQuery = Int32.Parse(Request.QueryString["id"]);


                StringBuilder sb2 = new StringBuilder();
                sb2.Append("SELECT A.TYPE_ID, B.TYPE_NAME FROM ITEM_DETAIL A, ITEM_TYPE B WHERE A.TYPE_ID=B.TYPE_ID AND ITEM_ID =" + rQuery);
                ArrayList rrayList = new ArrayList();
                rrayList = db.QueryDB(sb2.ToString());
                if (rrayList.Count > 0)
                {
                    foreach (Hashtable ht in rrayList)
                    {
                        DropDownList1.Items.Add(ht["TYPE_NAME"].ToString());
                    }
                }

                sb1.Append("SELECT ITEM_TITLE FROM ITEM_DETAIL WHERE ITEM_ID =" + rQuery);
                string title= db.GetOneColumnData(sb1.ToString());

                StringBuilder sb3 = new StringBuilder();
                sb3.Append("SELECT ITEM_PLACE FROM ITEM_DETAIL WHERE ITEM_ID =" + rQuery);
                string place = db.GetOneColumnData(sb3.ToString());

                StringBuilder sb4 = new StringBuilder();
                sb4.Append("SELECT ITEM_PIC FROM ITEM_DETAIL WHERE ITEM_ID =" + rQuery);
                string pic = db.GetOneColumnData(sb4.ToString());

                StringBuilder sb5 = new StringBuilder();
                sb5.Append("SELECT ITEM_DESCR FROM ITEM_DETAIL WHERE ITEM_ID =" + rQuery);
                string descr = db.GetOneColumnData(sb5.ToString());

                StringBuilder sb6 = new StringBuilder();
                sb6.Append("SELECT ITEM_COUNT FROM ITEM_DETAIL WHERE ITEM_ID =" + rQuery);
                string count = db.GetOneColumnData(sb6.ToString());

                StringBuilder sb7 = new StringBuilder();
                sb7.Append("SELECT ITEM_PRICE FROM ITEM_DETAIL WHERE ITEM_ID =" + rQuery);
                string price = db.GetOneColumnData(sb7.ToString());

                StringBuilder sb8 = new StringBuilder();
                sb8.Append("SELECT ITEM_OPEN FROM ITEM_DETAIL WHERE ITEM_ID =" + rQuery);
                string open = db.GetOneColumnData(sb8.ToString());
                open = open.Insert(4, "-");
                open = open.Insert(7, "-");
                StringBuilder sb9 = new StringBuilder();
                sb9.Append("SELECT ITEM_CLOSE FROM ITEM_DETAIL WHERE ITEM_ID =" + rQuery);
                string close = db.GetOneColumnData(sb9.ToString());
                close = close.Insert(4, "-");
                close = close.Insert(7, "-");

                StringBuilder sb10 = new StringBuilder();
                sb10.Append("SELECT ITEM_STATUS FROM ITEM_DETAIL WHERE ITEM_ID =" + rQuery);
                string status = db.GetOneColumnData(sb10.ToString());

                if (place == "ESkyMall")
                {
                    ITEM_TITLE.Text = title;
                    RadioButton1.Checked = true;
                    TextBox1.Text = pic;
                    ITEM_DESCR.Text = descr;
                    ITEM_COUNT.Text = count;
                    ITEM_PRICE.Text = price;
                    ITEM_OPEN.Text = open;
                    ITEM_CLOSE.Text = close;
                    ITEM_STATUS.Text = status;
                }
                else
                {
                    ITEM_TITLE.Text = title;
                    TextBox1.Text = pic;
                    RadioButton2.Checked = true;
                    ITEM_DESCR.Text = descr;
                    ITEM_COUNT.Text = count;
                    ITEM_PRICE.Text = price;
                    ITEM_OPEN.Text = open;
                    ITEM_CLOSE.Text = close;
                    ITEM_STATUS.Text = status;
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int rQuery = Int32.Parse(Request.QueryString["id"]);
            string fileName = FileUpload1.FileName.ToLower();
            string savePath = Server.MapPath("~/PIC/");
            string pathName = savePath + fileName;
            string relPath = "../../PIC/" + fileName;

            if (FileUpload1.HasFile)
            {
                FileUpload1.SaveAs(pathName);
            }
            StringBuilder sab = new StringBuilder();
            sab.Append("SELECT TYPE_ID FROM ITEM_TYPE WHERE TYPE_NAME='" + DropDownList1.Text + "'");
            string typeId = db.GetOneColumnData(sab.ToString());
            StringBuilder sb = new StringBuilder();

            string result = System.Text.RegularExpressions.Regex.Replace(ITEM_OPEN.Text, "[-]", "");
            string result2 = System.Text.RegularExpressions.Regex.Replace(ITEM_CLOSE.Text, "[-]", "");

            if (RadioButton1.Checked && CheckBox1.Checked)
            {
                sb.Append("UPDATE ITEM_DETAIL SET TYPE_ID=" + typeId + ", ITEM_TITLE='" + ITEM_TITLE.Text + "', ITEM_PLACE='" + RadioButton1.Text + "',ITEM_PIC='" + TextBox1.Text + "',ITEM_DESCR='" + ITEM_DESCR.Text + "', ITEM_COUNT=" + ITEM_COUNT.Text + ", ITEM_PRICE=" + ITEM_PRICE.Text + ",ITEM_OPEN=" + result + ",ITEM_CLOSE=" + result2 + ", ITEM_STATUS='" + ITEM_STATUS.Text + "' WHERE ITEM_ID=" + rQuery);
                //db.UpdateDB(sb.ToString());
                Response.Write(sb.ToString());

            }
            else if (RadioButton2.Checked && CheckBox1.Checked)
            {
                sb.Append("UPDATE ITEM_DETAIL SET TYPE_ID=" + typeId + ", ITEM_TITLE='" + ITEM_TITLE.Text + "', ITEM_PLACE='" + RadioButton2.Text + "',ITEM_PIC='" + TextBox1.Text + "',ITEM_DESCR='" + ITEM_DESCR.Text + "', ITEM_COUNT=" + ITEM_COUNT.Text + ", ITEM_PRICE=" + ITEM_PRICE.Text + ",ITEM_OPEN=" + result + ",ITEM_CLOSE=" +result2 + ", ITEM_STATUS='" + ITEM_STATUS.Text + "' WHERE ITEM_ID=" + rQuery);
                //db.UpdateDB(sb.ToString());
                Response.Write(sb.ToString());

            }
            else if (RadioButton1.Checked && CheckBox1 == null)
            {
                sb.Append("UPDATE ITEM_DETAIL SET TYPE_ID=" + typeId + ", ITEM_TITLE='" + ITEM_TITLE.Text + "', ITEM_PLACE='" + RadioButton1.Text + "',ITEM_PIC='" + relPath + "',ITEM_DESCR='" + ITEM_DESCR.Text + "', ITEM_COUNT=" + ITEM_COUNT.Text + ", ITEM_PRICE=" + ITEM_PRICE.Text + ",ITEM_OPEN=" + result + ",ITEM_CLOSE=" + result2 + ", ITEM_STATUS='" + ITEM_STATUS.Text + "' WHERE ITEM_ID=" + rQuery);
                //db.UpdateDB(sb.ToString());
                Response.Write(sb.ToString());
            }
            else
            {
                sb.Append("UPDATE ITEM_DETAIL SET TYPE_ID=" + typeId + ", ITEM_TITLE='" + ITEM_TITLE.Text + "', ITEM_PLACE='" + RadioButton2.Text + "',ITEM_PIC='" + relPath + "',ITEM_DESCR='" + ITEM_DESCR.Text + "', ITEM_COUNT=" + ITEM_COUNT.Text + ", ITEM_PRICE=" + ITEM_PRICE.Text + ",ITEM_OPEN=" + result + ",ITEM_CLOSE=" + result2 + ", ITEM_STATUS='" + ITEM_STATUS.Text + "' WHERE ITEM_ID=" + rQuery);
                //db.UpdateDB(sb.ToString());
                Response.Write(sb.ToString());
            }
            //Response.Redirect("~/WebAdmin/Commodity/Commodity.aspx");
        }
    }
}