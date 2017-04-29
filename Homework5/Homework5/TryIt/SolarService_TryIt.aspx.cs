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
    public partial class SolarService_TryIt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            decimal latitude = decimal.Parse(TextBox3.Text);
            decimal longitude = decimal.Parse(TextBox4.Text);
            String baseurl = "http://localhost:52501/Service1.svc/";
            string url = @baseurl + "SolarIntensity?lat=" + latitude + "&lon =" + longitude;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream responseStream = response.GetResponseStream();

            StreamReader reader = new StreamReader(responseStream);
            String json = reader.ReadToEnd();
            Console.WriteLine(json);

            result r = processJsonJavaScriptSerializer(json);
            if (r.status.Equals("Invalid Input"))
            {
                Label2.Text = "Invalid Input";
            }
            else
            {
                Label2.Text = r.avgIntensity.ToString();
            }


        }
        static result processJsonJavaScriptSerializer(String data)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            result r = js.Deserialize<result>(data);
            return r;
        }

        [Serializable]
        public class result
        {
            public decimal avgIntensity { get; set; }
            public String status { get; set; }

        }
    
    }
}