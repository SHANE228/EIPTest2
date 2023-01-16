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


namespace EIPTest
{
    public partial class test : System.Web.UI.Page
    {
        DataBase db = new DataBase();
        //檔名設定.txt
        public string ftpPath = "ITEM" + DateTime.Now.ToString("yyyyMMdd");
        public string msg = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            string strDt = DateTime.Today.ToString("yyyy-MM-dd");
            StringBuilder sb = new StringBuilder();
            ArrayList _arrayList = new ArrayList();
            
            sb.Append("SELECT A.ITEM_OPEN, A.ITEM_ID, A.TYPE_ID, B.TYPE_NAME, A.ITEM_TITLE, A.ITEM_COUNT, A.ITEM_PRICE, ITEM_PLACE FROM ITEM_DETAIL A, ITEM_TYPE B WHERE TRUNC (A.CREATE_TIME) = TO_DATE('"+strDt +"' ,'yyyy-MM-DD') AND A.TYPE_ID = B.TYPE_ID ");
            _arrayList = db.QueryDB(sb.ToString());
            if (_arrayList.Count >= 0)
            {
                foreach (Hashtable ht in _arrayList)
                {
                    //SELECT TYPE_NAME FROM ITEM_TYPE WHERE TYPE_ID=(SELECT TYPE_UPPER FROM ITEM_TYPE WHERE TYPE_ID = 2)
                    string str = ht["ITEM_OPEN"].ToString();
                    DateTime open = DateTime.ParseExact(str, "yyyyMMdd", null);

                    StringBuilder sb1 = new StringBuilder();
                    sb1.Append("SELECT TYPE_NAME FROM ITEM_TYPE WHERE TYPE_ID = (SELECT TYPE_UPPER FROM ITEM_TYPE WHERE TYPE_ID= " + ht["TYPE_ID"].ToString() + ")");
                    string bigName = db.GetOneColumnData(sb1.ToString());

                    string strOpen = open.ToString("yyyyMMdd");
                    string itemID = ht["ITEM_ID"].ToString();
                    string name = ht["TYPE_NAME"].ToString();
                    string title = ht["ITEM_TITLE"].ToString();
                    title = title.Trim();//去空白
                    string count = ht["ITEM_COUNT"].ToString();
                    string price = ht["ITEM_PRICE"].ToString();
                    string place = ht["ITEM_PLACE"].ToString();
                    //新增資料:上架日期、商品ID、大類名稱、小類名稱、商品標題(去空白)、數量、金額、販售地點(自動下一行)
                    msg += strOpen + "," + itemID + "," + bigName + "," + name + "," + title+ "," + count + "," + price + "," + place + "," + "\r\n";
                }
            }
            Append_String_To_File(msg);
            Ftp_Stream_Function();
        }

        /// <summary>
        /// 儲存資料到指定位置
        /// </summary>
        /// <param name="writeValue"></param>
        public void Append_String_To_File(string writeValue)
        {
            string path_Result_out = "C:\\ftpTest\\" + ftpPath + ".txt";

            //如果指定資料檔名不存在
            if (!File.Exists(path_Result_out))
            {
                //建立新的檔名.txt
                using (StreamWriter sw = File.CreateText(path_Result_out))
                {
                    sw.Write("\r\n");
                    sw.Write(writeValue);
                }
            }
            else
            {
                //附加現有檔案
                using (StreamWriter sw = File.AppendText(path_Result_out))
                {
                    sw.Write("\r\n");
                    sw.Write(writeValue);
                }

            }
        }
        /// <summary>
        /// 資料傳入到指定ftp位置
        /// </summary>
        public void Ftp_Stream_Function()
        {

            string path_Result_out = "C:\\ftpTest\\" + ftpPath + ".txt";
            string _Path_Result_out = ftpPath + ".txt";
            //獲取與Server 通訊的對象
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://192.168.56.1//" + _Path_Result_out);
            request.Method = WebRequestMethods.Ftp.UploadFile;

            //使用者登入ftp帳號與密碼
            request.Credentials = new NetworkCredential("ym387", "ym78866026");

            //將文件文件內容複製到ftp
            StreamReader sourceStream = new StreamReader(path_Result_out);
            byte[] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
            sourceStream.Close();
            request.ContentLength = fileContents.Length;

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(fileContents, 0, fileContents.Length);
            requestStream.Close();

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            response.Close();
        }
    }
}