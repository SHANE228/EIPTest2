using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace EIPTest.lib.AES
{
    public class MyAesCryptography
    {
        public string myKey = "1234567812345678";
        public string myIV = "1234567812345678";
        /// <summary>
        /// 驗證key和iv的長度(AES只有三種長度適用)
        /// </summary>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        private static void Validate_KeyIV_Length(string key, string iv)
        {
            //驗證key和iv都必須為128bits或192bits或256bits
            List<int> LegalSizes = new List<int>() { 128, 192, 256 };
            int keyBitSize = Encoding.UTF8.GetBytes(key).Length * 8;
            int ivBitSize = Encoding.UTF8.GetBytes(iv).Length * 8;
            if (!LegalSizes.Contains(keyBitSize) || !LegalSizes.Contains(ivBitSize))
            {
                throw new Exception($@"key或iv的長度不在128bits、192bits、256bits其中一個，輸入的key bits:{keyBitSize},iv bits:{ivBitSize}");
            }
        }
        /// <summary>
        /// 加密後回傳base64String
        /// 相同明碼文字編碼後的base64String結果會相同，除非變更key或iv
        /// </summary>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        /// <param name="plain_text"></param>
        /// <returns></returns>
        public static string Encrypt(string key, string iv, string plain_text)
        {


            Validate_KeyIV_Length(key, iv);
            Aes aes = Aes.Create();
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            ICryptoTransform transform = aes.CreateEncryptor(Encoding.UTF8.GetBytes(key), Encoding.UTF8.GetBytes(iv));

            byte[] bPlainText = Encoding.UTF8.GetBytes(plain_text);//明碼文字轉byte[]
            byte[] outputData = transform.TransformFinalBlock(bPlainText, 0, bPlainText.Length);//加密
            return Convert.ToBase64String(outputData);
        }
        /// <summary>
        /// 解密後，回傳明碼文字
        /// </summary>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        /// <param name="base64String"></param>
        /// <returns></returns>
        public static string Decrypt(string key, string iv, string base64String)
        {


            Validate_KeyIV_Length(key, iv);
            Aes aes = Aes.Create();
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            ICryptoTransform transform = aes.CreateDecryptor(Encoding.UTF8.GetBytes(key), Encoding.UTF8.GetBytes(iv));
            byte[] bEnBase64String = null;
            byte[] outputData = null;
            try
            {
                bEnBase64String = Convert.FromBase64String(base64String);//有可能base64String格式錯誤
                outputData = transform.TransformFinalBlock(bEnBase64String, 0, bEnBase64String.Length);//有可能解密出錯
            }
            catch (Exception ex)
            {
                //todo 寫Log
                throw new Exception($@"解密出錯:{ex.Message}");
            }

            //解密成功
            return Encoding.UTF8.GetString(outputData);

        }
        /// <summary>
        /// 防止SQL injection,查詢輸入字串消除以下字囊
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ReplaceSQLChar(string str)
        {
            if (str == String.Empty)
                return String.Empty;
            str = str.Replace("'", "");
            str = str.Replace(";", "");
            str = str.Replace("--", "");
            str = str.Replace(",", "");
            str = str.Replace("?", "");
            str = str.Replace("<", "");
            str = str.Replace(">", "");
            str = str.Replace("(", "");
            str = str.Replace(")", "");
            str = str.Replace("1=1", "");
            str = str.Replace("=", "");
            str = str.Replace("+", "");
            str = str.Replace("*", "");

            //刪除與資料庫相關的字囊
            str = Regex.Replace(str, "select", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "insert", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "delete from", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "count", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "drop table", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "truncate", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "asc", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "mid", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "char", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "and", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "or", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "-", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "delete", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "drop", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "script", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "update", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "and", "", RegexOptions.IgnoreCase);

            return str;
        }
    }
}