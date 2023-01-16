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
using Quartz;
using System.Threading;

namespace EIPTest.schedule
{
    public partial class close : System.Web.UI.Page
    {
        DataBase db = new DataBase();
        public ArrayList _arrayList = new ArrayList();
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            //如果下架日期<=今日，且商品狀態非'刪除'，下架商品全數呼叫出來
            sb.Append("SELECT ITEM_ID FROM ITEM_DETAIL WHERE ITEM_CLOSE <= TO_NUMBER(TO_CHAR(SYSDATE,'yyyymmdd')) AND NOT ITEM_STATUS ='D'");
            _arrayList = db.QueryDB(sb.ToString());
            if (_arrayList.Count >= 0)
            {
                foreach (Hashtable ht in _arrayList)
                {
                    string title = ht["ITEM_ID"].ToString();
                    StringBuilder sba = new StringBuilder();
                    //架下商品改成'N'為下架
                    sba.Append("UPDATE ITEM_DETAIL SET ITEM_STATUS = 'N', MODIFY_TIME = SYSDATE WHERE ITEM_ID = " + title + "");
                    db.UpdateDB(sba.ToString());
                }
            }
        }
    }
}