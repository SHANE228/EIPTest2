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
        public string ftpPath = "ITEM" + DateTime.Now.ToString("yyyyMMdd");
        public string msg = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            string strDt = DateTime.Today.ToString("yyyy-MM-dd");
            StringBuilder sb = new StringBuilder();
            ArrayList _arrayList = new ArrayList();
            //SELECT TYPE_NAME FROM ITEM_TYPE WHERE TYPE_ID=(SELECT TYPE_UPPER FROM ITEM_TYPE WHERE TYPE_ID = 2)
            sb.Append("SELECT A.ITEM_OPEN, A.ITEM_ID, B.TYPE_NAME, A.ITEM_TITLE, A.ITEM_COUNT, A.ITEM_PRICE, ITEM_PLACE FROM ITEM_DETAIL A, ITEM_TYPE B WHERE TRUNC (A.CREATE_TIME) = TO_DATE("+strDt +" ,'yyyy-MM-DD') AND A.TYPE_ID = B.TYPE_ID ");
            _arrayList = db.QueryDB(sb.ToString());
            if (_arrayList.Count >= 0)
            {
                foreach (Hashtable ht in _arrayList)
                {
                    string str = ht["ITEM_OPEN"].ToString();
                    DateTime open = DateTime.ParseExact(str, "yyyyMMdd", null);

                    string strOpen = open.ToString("yyyyMMdd");
                    string itemID = ht["ITEM_ID"].ToString();
                    string name = ht["TYPE_NAME"].ToString();
                    string title = ht["ITEM_TITLE"].ToString();
                    string count = ht["ITEM_COUNT"].ToString();
                    string price = ht["ITEM_PRICE"].ToString();
                    string place = ht["ITEM_PLACE"].ToString();
                    msg += strOpen + "," + itemID + "," + name + "," + title + "," + count + "," + price + "," + place + "," + "\r\n";
                }
            }
            Append_String_To_File(msg);
            Ftp_Stream_Function();
        }

        public void Append_String_To_File(string writeValue)
        {
            string path_Result_out = "C:\\ftpTest\\" + ftpPath + ".txt";

            if (!File.Exists(path_Result_out))
            {
                using (StreamWriter sw = File.CreateText(path_Result_out))
                {
                    sw.Write("\r\n");
                    sw.Write(writeValue);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(path_Result_out))
                {
                    sw.Write("\r\n");
                    sw.Write(writeValue);
                }

            }
        }
        public void Ftp_Stream_Function()
        {

            string path_Result_out = "C:\\ftpTest\\" + ftpPath + ".txt";
            string _Path_Result_out = ftpPath + ".txt";
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://192.168.4.137//" + _Path_Result_out);
            request.Method = WebRequestMethods.Ftp.UploadFile;

            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential("ym387", "ym78866026");

            // Copy the contents of the file to the request stream.
            StreamReader sourceStream = new StreamReader(path_Result_out);
            byte[] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
            sourceStream.Close();
            request.ContentLength = fileContents.Length;

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(fileContents, 0, fileContents.Length);
            requestStream.Close();

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            //Console.WriteLine("Upload File Complete, status {0}", response.StatusDescription);

            response.Close();
        }
    }
}