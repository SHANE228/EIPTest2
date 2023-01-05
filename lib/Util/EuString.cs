using System;
using System.IO;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Text;
using System.Web;

namespace EIPTest.lib.Util
{
    public class EuString
    {


        public EuString()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }

        /**
            * 避免秀出 null 字樣
            */
        public static String DisplayNull(String InputString)
        {

            if (string.IsNullOrEmpty(InputString))
            {
                return "";
            }
            else
            {
                return InputString;
            }

        }
    }
}