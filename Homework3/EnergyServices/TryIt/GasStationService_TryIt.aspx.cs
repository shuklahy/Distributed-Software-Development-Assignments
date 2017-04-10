using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TryIt
{
    public partial class GasStationService_TryIt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            double lat = Double.Parse(TextBox3.Text);
            double lon = Double.Parse(TextBox4.Text);

            String baseurl = "http://10.1.22.105:8001/Service1.svc";
            string url = @baseurl + "/getGasStation?lat=" + lat + "&lon=" + lon;
            

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream responseStream = response.GetResponseStream();

            StreamReader reader = new StreamReader(responseStream);
            String json = reader.ReadToEnd();
            Console.WriteLine(json);

            result[] output = processJsonJavaScriptSerializer(json);
            ListView1.DataSource = output;
            ListView1.DataBind();


        }
        static result[] processJsonJavaScriptSerializer(String data)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            result[] r = js.Deserialize<result []>(data);
            return r;
        }

        [Serializable]
        public class result
        {
            public String name { get; set; }
            public String openNow { get; set; }
            public String address { get; set; }
        }
        
    }
}
