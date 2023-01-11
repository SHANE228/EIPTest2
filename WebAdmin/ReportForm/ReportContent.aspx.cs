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
    public partial class ReportContentaspx : System.Web.UI.Page
    {
        public DataBase db = new DataBase();
        public ArrayList _arrayList = new ArrayList();
        public ArrayList _arrayList1 = new ArrayList();
        public ArrayList _arrayList2 = new ArrayList();


        protected void Page_Load(object sender, EventArgs e)
        {
            int a1 = 0, b1 = 0, c1 = 0, d1 = 0, e1 = 0, f1 = 0, g1 = 0;
            int rQuery = Int32.Parse(Request.QueryString["id"]);
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT A.ITEM_ID, B.TYPE_NAME, A.ITEM_OPEN, A.ITEM_CLOSE, A.ITEM_VIEW_COUNT, C.FAV_STATUS FROM ITEM_DETAIL A, ITEM_TYPE B, MEMBER_FAVORITE C WHERE A.TYPE_ID = B.TYPE_ID AND A.ITEM_ID = C.ITEM_ID AND C.FAV_STATUS = 'Y'");
            _arrayList = db.QueryDB(sb.ToString());

            //被那些會員加入喜好清單統計
            StringBuilder sb1 = new StringBuilder();
            sb1.Append("SELECT A.MEMBER_ID, B.EMP_ID FROM MEMBER_FAVORITE A, SJ0007_LOGIN B WHERE A.MEMBER_ID = B.SERIAL_ID AND A.ITEM_ID = "+rQuery);
            _arrayList1 = db.QueryDB(sb1.ToString());

            //被加入喜好清單次數
            StringBuilder sba = new StringBuilder();
            sba.Append("SELECT COUNT(*) FROM MEMBER_FAVORITE WHERE ITEM_ID =" + rQuery);
            string frequency = db.GetOneColumnData(sba.ToString());
            Label1.Text = "被加入喜好清單次數:" + frequency;

            //性別分布
            //男
            StringBuilder sb2 = new StringBuilder();
            sb2.Append("SELECT COUNT(A.EMP_SEX) FROM SJ0007_LOGIN A, MEMBER_FAVORITE B WHERE A.SERIAL_ID=B.MEMBER_ID AND A.EMP_SEX =1 AND B.ITEM_ID = " + rQuery);
            string boy = db.GetOneColumnData(sb2.ToString());

            //女
            StringBuilder sb3 = new StringBuilder();
            sb3.Append("SELECT COUNT(A.EMP_SEX) FROM SJ0007_LOGIN A, MEMBER_FAVORITE B WHERE A.SERIAL_ID=B.MEMBER_ID AND A.EMP_SEX =2 AND B.ITEM_ID = " + rQuery);
            string girl = db.GetOneColumnData(sb3.ToString());

            Label2.Text = "性別分布(男" + boy + "人, 女" + girl + "人)";
            //年齡分布
            StringBuilder sb4 = new StringBuilder();
            sb4.Append("SELECT TRUNC(MONTHS_BETWEEN( SYSDATE, TO_DATE(EMP_BIRTHDAY,'YYYYMMDD'))/12) AS AGE FROM SJ0007_LOGIN A, MEMBER_FAVORITE B WHERE A.SERIAL_ID=B.MEMBER_ID AND B.ITEM_ID=" + rQuery);
            _arrayList2 = db.QueryDB(sb4.ToString());

            if (_arrayList2.Count > 0)
            {
                foreach (Hashtable htt in _arrayList2)
                {
                    string age = htt["AGE"].ToString();
                    int intAge = Int32.Parse(age);
                    if(intAge>=0&& intAge <= 18)
                    {
                        a1++;
                    }
                    else if (intAge >= 19 && intAge <= 29)
                    {
                        b1++;
                    }
                    else if (intAge >= 30&&intAge <= 39)
                    {
                        c1++;
                    }
                    else if (intAge >= 40 && intAge <= 49)
                    {
                        d1++;
                    }
                    else if (intAge >= 50 && intAge <= 59)
                    {
                        e1++;
                    }
                    else if (intAge >= 60 && intAge <= 69)
                    {
                        f1++;
                    }
                    else
                    {
                        g1++;
                    }
                }
            }
            Label3.Text = "年齡分布:<br> 小於18 :" + a1 + "人, 19-29 :" + b1 + "人, 30-39 :" + c1 + "人 , 40-49 :" + d1 + "人 <br>, 50-59 :" + e1 + "人, 60-69 :" + f1 + "人, 69以上 :" + g1 + "人";
        }
    }
}