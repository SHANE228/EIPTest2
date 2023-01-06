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
    public partial class EditCommodity : System.Web.UI.Page
    {
        DataBase db = new DataBase();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                StringBuilder sb1 = new StringBuilder();
                int rQuery = Int32.Parse(Request.QueryString["id"]);
                sb1.Append("SELECT NOTICE_TOPIC FROM NOTICE_DETAIL WHERE NOTICE_ID=" + rQuery);
                string topic = db.GetOneColumnData(sb1.ToString());

                StringBuilder sb2 = new StringBuilder();
                sb2.Append("SELECT NOTICE_CONTENT FROM NOTICE_DETAIL WHERE NOTICE_ID=" + rQuery);
                string content = db.GetOneColumnData(sb2.ToString());

                StringBuilder sb3 = new StringBuilder();
                sb3.Append("SELECT NOTICE_OPEN FROM NOTICE_DETAIL WHERE NOTICE_ID=" + rQuery);
                string open = db.GetOneColumnData(sb3.ToString());
                open = open.Insert(4, "-");
                open = open.Insert(7, "-");

                StringBuilder sb4 = new StringBuilder();
                sb4.Append("SELECT NOTICE_CLOSE FROM NOTICE_DETAIL WHERE NOTICE_ID=" + rQuery);
                string close = db.GetOneColumnData(sb4.ToString());
                close = close.Insert(4, "-");
                close = close.Insert(7, "-");
                TextBox1.Text = topic;
                TextBox2.Text = content;
                TextBox3.Text = open;
                TextBox4.Text = close;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/WebAdmin/Commodity/Commodity.aspx");
        }
    }
}