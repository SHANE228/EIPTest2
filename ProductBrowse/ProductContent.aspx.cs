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
        public DataBase db = new DataBase();
        public ArrayList _arrayList = new ArrayList();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["empId"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            int rQuery = Int32.Parse(MyAesCryptography.ReplaceSQLChar(Request.QueryString["id"]));
            EmpObject empBasic = new EmpObject(Session["empId"].ToString());
            if (!IsPostBack)
            {
                //抓取商品內容
                StringBuilder sba = new StringBuilder();
                sba.Append("SELECT ITEM_VIEW_COUNT FROM ITEM_DETAIL WHERE ITEM_ID= " + rQuery);
                string ivc = db.GetOneColumnData(sba.ToString());

                //瀏覽數+1並且儲存到資料庫
                int intIvc = Int32.Parse(ivc) + 1;
                StringBuilder sbc = new StringBuilder();
                sbc.Append("UPDATE ITEM_DETAIL SET ITEM_VIEW_COUNT=" + intIvc + " WHERE ITEM_ID= " + rQuery);
                db.UpdateDB(sbc.ToString());
                Label1.Text = intIvc.ToString();

                //判斷該帳號事先加入喜好清單?
                StringBuilder ssb = new StringBuilder();
                ssb.Append("SELECT A.FAV_STATUS FROM MEMBER_FAVORITE A, SJ0007_LOGIN B WHERE A.ITEM_ID=" + rQuery + "AND A.MEMBER_ID = B.SERIAL_ID AND B.EMP_ID='" + empBasic.empId + "'");
                string data = db.GetOneColumnData(ssb.ToString());
                if (data == "Y")
                {
                    //事先加入喜好清單，加入喜好清單關閉
                    Button1.Enabled = false;
                    Button1.Visible = false;
                }
                else
                {
                    //尚未加入喜好清單，清除喜好清單按鈕移除
                    Button2.Enabled = false;
                    Button2.Visible = false;
                }
            }
            //導入商品內容
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT A.ITEM_ID, A.TYPE_ID, A.ITEM_TITLE, A.ITEM_PIC, A.ITEM_DESCR, A.ITEM_COUNT, A.ITEM_PRICE, A.ITEM_OPEN, A.ITEM_CLOSE, A.ITEM_STATUS, B.TYPE_NAME FROM ITEM_DETAIL A,ITEM_TYPE B WHERE A.TYPE_ID = B.TYPE_ID AND NOT A.ITEM_STATUS ='D' AND NOT A.ITEM_STATUS ='N' AND A.ITEM_ID="+ rQuery);
            _arrayList = db.QueryDB(sb.ToString());

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int rQuery = Int32.Parse(MyAesCryptography.ReplaceSQLChar(Request.QueryString["id"]));
            EmpObject empBasic = new EmpObject(Session["empId"].ToString());
            StringBuilder ssb = new StringBuilder();
            ssb.Append("SELECT FAV_ID FROM MEMBER_FAVORITE WHERE ITEM_ID=" + rQuery + "AND MEMBER_ID ="+empBasic.serial_Id);
            string BData = db.GetOneColumnData(ssb.ToString());
            if (BData == "")
            {
                string serial_ID = db.GetSequence("SJ0007_FAV");
                StringBuilder sb1 = new StringBuilder();
                sb1.Append("INSERT INTO MEMBER_FAVORITE ( FAV_ID, MEMBER_ID, ITEM_ID, FAV_STATUS, CREATE_TIME, WHO_CREATE, MODIFY_TIME, WHO_MODIFY )");
                sb1.Append("VALUES (" + serial_ID + "," + empBasic.serial_Id + "," + rQuery + ", 'Y', SYSDATE,'" + empBasic.empId + "', SYSDATE ,'" + empBasic.empId + "')");
                db.UpdateDB(sb1.ToString());
            }
            else
            {
                StringBuilder sb1 = new StringBuilder();
                sb1.Append("UPDATE MEMBER_FAVORITE SET FAV_STATUS = 'Y', MODIFY_TIME= SYSDATE, DELETE_TIME=NULL WHERE ITEM_ID=" + rQuery);
                db.UpdateDB(sb1.ToString());
                Response.Write(sb1.ToString());
            }
            Button2.Enabled = true;
            Button2.Visible = true;
            Button1.Enabled = false;
            Button1.Visible = false;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int rQuery = Int32.Parse(MyAesCryptography.ReplaceSQLChar(Request.QueryString["id"]));
            StringBuilder sb2 = new StringBuilder();
            sb2.Append("UPDATE MEMBER_FAVORITE SET FAV_STATUS = 'D', MODIFY_TIME= SYSDATE, DELETE_TIME=SYSDATE WHERE ITEM_ID=" + rQuery);
            db.UpdateDB(sb2.ToString());
            Button1.Enabled = true;
            Button1.Visible = true;
            Button2.Enabled = false;
            Button2.Visible = false;
        }
    }
}