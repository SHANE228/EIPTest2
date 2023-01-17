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
    public partial class CreateCategory : System.Web.UI.Page
    {
        DataBase db = new DataBase();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("~/WebAdmin/AdminDefault.aspx");
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            StringBuilder sba = new StringBuilder();
            string serial_ID = db.GetSequence("SJ0007_CATEGORY");
            //檢核類別代碼是否重複
            sba.Append("SELECT COUNT(*) FROM ITEM_TYPE WHERE TYPE_CODE = '" + CategoryCode.Text + "'");
            string gocl = db.GetOneColumnData(sba.ToString());
            int intGcl = Int32.Parse(gocl);
            if (intGcl != 0)
            {
                Label1.Text = "類別代碼重複";
            }
            else
            {
                string msg = "";
                msg = DropDownList1.Text;
                if (msg == "大類")
                {
                    if (UpperCode.Text != "")
                    {
                        Label1.Text = "大類上層代碼需為空值";
                    }
                    else
                    {
                        int intMsg = 1;
                        StringBuilder sb = new StringBuilder();
                        sb.Append("INSERT INTO ITEM_TYPE (TYPE_ID, TYPE_LEVEL, TYPE_CODE, TYPE_STATUS, TYPE_NAME, TYPE_PS, CREATE_TIME, WHO_CREATE, MODIFY_TIME, WHO_MODIFY)");
                        sb.Append("VALUES(" + serial_ID + "," + intMsg + ",'" + MyAesCryptography.ReplaceSQLChar(CategoryCode.Text) + "', 'Y' ,'" + MyAesCryptography.ReplaceSQLChar(CategoryName.Text) + "','" + MyAesCryptography.ReplaceSQLChar(CategoryCaption.Text) + "', SYSDATE, 'SYS_ADMIN', SYSDATE,'SYS_ADMIN')");
                        db.UpdateDB(sb.ToString());
                        Response.Redirect("~/WebAdmin/Category/CommodityCategory.aspx");
                    }
                }
                if (msg == "小類")
                {
                    int intMsg = 2;
                    StringBuilder sb = new StringBuilder();
                    sb.Append("INSERT INTO ITEM_TYPE (TYPE_ID, TYPE_LEVEL, TYPE_UPPER, TYPE_CODE, TYPE_STATUS, TYPE_NAME, TYPE_PS, CREATE_TIME, WHO_CREATE, MODIFY_TIME, WHO_MODIFY)");
                    sb.Append("VALUES(" + serial_ID + "," + intMsg + ",'" + MyAesCryptography.ReplaceSQLChar(UpperCode.Text) + "','" + MyAesCryptography.ReplaceSQLChar(CategoryCode.Text) + "', 'Y' ,'" + MyAesCryptography.ReplaceSQLChar(CategoryName.Text) + "','" + MyAesCryptography.ReplaceSQLChar(CategoryCaption.Text) + "', SYSDATE, 'SYS_ADMIN', SYSDATE,'SYS_ADMIN')");
                    db.UpdateDB(sb.ToString());
                    Response.Redirect("~/WebAdmin/Category/CommodityCategory.aspx");
                }
                
            }
        }
    }
}