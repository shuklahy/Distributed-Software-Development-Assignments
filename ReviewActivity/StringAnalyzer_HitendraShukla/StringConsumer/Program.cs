using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;

namespace StringConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter a string: ");
                String str = Console.ReadLine();

                string url = @"http://localhost:56657/Service1.svc/analyze/" + str;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                WebResponse response = request.GetResponse();
                Stream responseStream = response.GetResponseStream();

                StreamReader reader = new StreamReader(responseStream);
                String json = reader.ReadToEnd();

                //Console.WriteLine("Received Json REsponse is");
                //Console.WriteLine(json);

                processJsonJavaScriptSerializer(json);

                
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Console.WriteLine("Press Any Key to Exit");
                Console.Read();
            }
        }

        static void processJsonJavaScriptSerializer(String data)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            StringDetailsClass sd = js.Deserialize<StringDetailsClass>(data);

            Console.WriteLine("Digits : "+sd.digitCount);
            Console.WriteLine("Uppercase Letters: "+sd.upperCaseCount);
            Console.WriteLine("Lowercase Letters: " + sd.lowerCaseCount);

        }

        [Serializable]
        public class StringDetailsClass
        {
            public int digitCount { get; set; }
            public int upperCaseCount { get; set; }
            public int lowerCaseCount { get; set; }
        }
    }
}
