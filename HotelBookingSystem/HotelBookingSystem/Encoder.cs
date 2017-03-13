using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem
{
    class Encoder
    {
        public static String encode(OrderClass o, String key)
        {
            String encodedString = "";
            String input = ""+ o.SenderId + "," + o.CardNo + "," + o.ReceiverId + "," + o.Amount + "," + o.Timestamp; 

            byte[] inputArray = UTF8Encoding.UTF8.GetBytes(input);
            try
            {
                TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
                tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
                tripleDES.Mode = CipherMode.ECB;
                tripleDES.Padding = PaddingMode.PKCS7;
                ICryptoTransform cTransform = tripleDES.CreateEncryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
                tripleDES.Clear();
                encodedString = Convert.ToBase64String(resultArray, 0, resultArray.Length);
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.ToString());
            }
            

            return encodedString;
        }
    }
}
