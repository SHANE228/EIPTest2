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
    public class CreateProduct :IJob
    {
        private bool _stopping = false;

        private void Log(string msg)
        {

        }
        public void SendProduct()
        {
            string msg = String.Format("SendProduct() at {0:yyyy/MM/dd HH:mm:ss}", DateTime.Now);
            Log(msg);
            Thread.Sleep(2000);
        }
        public Task Execute(IJobExecutionContext context)
        {
            SendProduct();
            throw new NotImplementedException();
        }

    }
}