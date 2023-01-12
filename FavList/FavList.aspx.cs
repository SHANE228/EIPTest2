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

namespace EIPTest.FavList
{
    public partial class FavList : System.Web.UI.Page
    {
        DataBase db = new DataBase();
        public ArrayList _arrayList = new ArrayList();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["empId"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            EmpObject empBasic = new EmpObject(Session["empId"].ToString());
            //SELECT 商品管理內容，且排除刪除狀態
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT A.ITEM_ID, A.ITEM_PIC , A.ITEM_TITLE, A.TYPE_ID, B.TYPE_NAME, A.ITEM_STATUS, A.ITEM_PLACE,C.CREATE_TIME FROM ITEM_DETAIL A, ITEM_TYPE B, MEMBER_FAVORITE C WHERE A.TYPE_ID=B.TYPE_ID AND C.ITEM_ID=A.ITEM_ID AND C.FAV_STATUS='Y' AND C.WHO_MODIFY ='" +empBasic.empId + "'");
            _arrayList = db.QueryDB(sb.ToString());
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            //前端hidden商品代號傳到後端辨識每個商品，且商品狀態修改成 'D'
            string reData = Request.Form["member"];
            StringBuilder sb2 = new StringBuilder();
            sb2.Append("UPDATE MEMBER_FAVORITE SET FAV_STATUS = 'D', MODIFY_TIME= SYSDATE, DELETE_TIME=SYSDATE WHERE ITEM_ID=" +reData);
            db.UpdateDB(sb2.ToString());
            Response.Write(sb2.ToString());
        }
    }
}