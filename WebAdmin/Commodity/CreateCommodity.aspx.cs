﻿using System;
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
    public partial class CreateCommodity : System.Web.UI.Page
    {
        DataBase db = new DataBase();
        public ArrayList _arrayList;
        public ArrayList _arrayList2;

        protected void Page_Init(object sender, EventArgs e)
        {

            StringBuilder sb = new StringBuilder();
            StringBuilder sb1 = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();

            ArrayList rrayList = new ArrayList();
            sb.Append("SELECT TYPE_ID, TYPE_NAME FROM ITEM_TYPE WHERE TYPE_LEVEL = 1");
            rrayList = db.QueryDB(sb.ToString());
            if (rrayList.Count > 0)
            {
                foreach (Hashtable ht in rrayList)
                {
                    DropDownList1.Items.Add(ht["TYPE_NAME"].ToString());
                }
                //Panel1.Controls.Add(DropDownList1);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    _arrayList = new ArrayList();
            //    StringBuilder sb = new StringBuilder();
            //    sb.Append("SELECT TYPE_NAME FROM ITEM_TYPE WHERE TYPE_LEVEL = 1");
            //    _arrayList = db.QueryDB(sb.ToString());
            //    string Bcs = Request["Bclass"];
            //}

            //if (Bcs != null)
            //{
            //    StringBuilder sb1 = new StringBuilder();
            //    StringBuilder sb2 = new StringBuilder();
            //    sb1.Append("SELECT TYPE_ID FROM ITEM_TYPE WHERE TYPE_NAME ='" + Bcs + "'");
            //    string BData = db.GetOneColumnData(sb1.ToString());
            //    int intBData = Int32.Parse(BData);
            //    sb2.Append("SELECT TYPE_NAME FROM ITEM_TYPE WHERE TYPE_UPPER=" + intBData);
            //    _arrayList2 = db.QueryDB(sb2.ToString());
            //}
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string fileName = FileUpload1.FileName.ToLower();
            string savePath = Server.MapPath("~/PIC/");
            string pathName = savePath + fileName;
            if (FileUpload1.HasFile)
            {
                FileUpload1.SaveAs(pathName);
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT TYPE_NAME FROM ITEM_TYPE WHERE TYPE_LEVEL = 1");
            _arrayList = db.QueryDB(sb.ToString());
            string Bcs = Request["Bclass"];
            Response.Write(Bcs);
        }


        protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            StringBuilder sb3 = new StringBuilder();
            StringBuilder sb4 = new StringBuilder();

            ArrayList rrayList2 = new ArrayList();
            sb3.Append("SELECT TYPE_ID FROM ITEM_TYPE WHERE TYPE_NAME ='" + DropDownList1.Text + "'");
            string BData = db.GetOneColumnData(sb3.ToString());
            int intBData = Int32.Parse(BData);
            sb4.Append("SELECT TYPE_NAME FROM ITEM_TYPE WHERE TYPE_UPPER=" + intBData);
            rrayList2 = db.QueryDB(sb4.ToString());
            if (rrayList2.Count > 0)
            {
                foreach (Hashtable ht2 in rrayList2)
                {
                    DropDownList2.Items.Add(ht2["TYPE_NAME"].ToString());
                }
            }
        }
    }
}