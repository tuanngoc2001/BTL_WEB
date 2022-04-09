using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_ASPNETCORE.Areas.Admin.Data
{
    public class StringProcessing
    {
        public static string CreateMD5Hash(string input)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            //chuyển thành mã asscii
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            //băm ra kiểu byte
            byte[] hasBytes = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hasBytes.Length; i++)
            {
                sb.Append(hasBytes[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
