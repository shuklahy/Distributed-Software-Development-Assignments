using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem
{
    class Decoder
    {
        public static OrderClass decode(String encodedObjStr, String key)
        {
            
            Byte[] inputArray = Convert.FromBase64String(encodedObjStr);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateDecryptor();
            Byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            String rawString =  UTF8Encoding.UTF8.GetString(resultArray);

            //Populate objects with decrypted String
            String[] words = rawString.Split(',');
            int SenderId = Int32.Parse(words[0]);
            int CardNo = Int32.Parse(words[1]);
            int ReceiverId = Int32.Parse(words[2]);
            int Amount = Int32.Parse(words[3]);
            string timestamp = words[4];

            return new OrderClass(SenderId, CardNo, ReceiverId, Amount, timestamp);
        }
    }
}
