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

namespace EIPTest.WebAdmin.ReportForm
{
    public partial class ReportAnalysis : System.Web.UI.Page
    {
        public DataBase db = new DataBase();
        public ArrayList _arrayList = new ArrayList();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("~/WebAdmin/AdminDefault.aspx");
            }
            //商品TOP3
            StringBuilder sb = new StringBuilder();
            // LISTAGG WITHIN GROUP串聯多筆成一筆，如果需多一筆欄位，在 SELECT 和 GROUP BY加欄位。
            sb.Append("SELECT * FROM(SELECT ITEM_VIEW_COUNT, LISTAGG (ITEM_TITLE ,',') WITHIN GROUP(ORDER BY ITEM_TITLE) AS ITEM_TITLE FROM ITEM_DETAIL GROUP BY ITEM_VIEW_COUNT ORDER BY ITEM_VIEW_COUNT DESC) WHERE ROWNUM<= 3");
            _arrayList = db.QueryDB(sb.ToString());

            //近30天
            //string strDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")).AddMonths(-1).ToString();
            //DateTime dateDt = DateTime.Parse(strDate);
            //for (DateTime dt = dateDt; dt <= DateTime.Now; dt = dt.AddDays(1))
            //{
            //    string msgnd = dt.ToString("yyyy-MM-dd");
            //    //每日新增男性
            //    StringBuilder sb1 = new StringBuilder();
            //    sb1.Append("SELECT COUNT(EMP_SEX) AS AGE FROM SJ0007_LOGIN WHERE TRUNC (CREATE_TIME) = TO_DATE('" + msgnd + "' ,'yyyy-MM-DD') AND EMP_SEX=1");
            //    string boy = db.GetOneColumnData(sb1.ToString());

            //    //每日新增女性
            //    StringBuilder sb2 = new StringBuilder();
            //    sb2.Append("SELECT COUNT(EMP_SEX) AS AGE FROM SJ0007_LOGIN WHERE TRUNC (CREATE_TIME) = TO_DATE('" + msgnd + "' ,'yyyy-MM-DD') AND EMP_SEX=2");
            //    string girl = db.GetOneColumnData(sb2.ToString());
            //    Label1.Text += "日期: " + msgnd + "" + "每日新增會員" + "" + "男:" + boy + " 人,女:" + girl + "人 <br><br>";
            //}
        }
    }
}