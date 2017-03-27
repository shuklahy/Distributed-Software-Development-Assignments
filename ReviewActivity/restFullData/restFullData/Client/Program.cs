using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Net.Http;
using System.Net;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "Janaka";
            int age = 10;

            //string url = @"http://localhost:61325/Service1.svc/analyze/" + origin;
            string url = @"http://localhost:22815/Service1.svc/setNameAgeJson/"+name+"/"+age;
           
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream responseStream = response.GetResponseStream();

            StreamReader reader = new StreamReader(responseStream);
            String json = reader.ReadToEnd();
            Console.WriteLine(json);
            processJsonJavaScriptSerializer(json);
            processJsonNewtonSoft(json);



        }
        static void processJsonJavaScriptSerializer(String data)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            personInfo p = js.Deserialize<personInfo>(data);
            Console.WriteLine(p.age);

        }

        static void processJsonNewtonSoft(String data)
        {
            personInfo p = JsonConvert.DeserializeObject<personInfo>(data);
            Console.WriteLine(p.age);

        }


        [Serializable]
        public class personInfo
        {
            public string name { get; set; }
            public int age { get; set; }
        }
    }
}
