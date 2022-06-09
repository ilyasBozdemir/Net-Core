using System.Text;
using System.Security.Cryptography;

namespace MovieStore.Application.Helpers
{
    public class SiteCryptography
    {
        public static string MD5Sifrele(string sifrelenecekMetin)
        {

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            byte[] dizi = Encoding.UTF8.GetBytes(sifrelenecekMetin);
            dizi = md5.ComputeHash(dizi);
            StringBuilder sb = new StringBuilder();

            foreach (byte ba in dizi)
            {
                sb.Append(ba.ToString("x2").ToLower());
            }
            return sb.ToString();
        }
    }
}

