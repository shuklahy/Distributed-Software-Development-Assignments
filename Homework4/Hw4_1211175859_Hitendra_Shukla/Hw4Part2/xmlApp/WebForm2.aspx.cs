using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace xmlApp
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string xmlPath = TextBox3.Text;
            string expression = TextBox5.Text;

            String baseurl = "http://localhost:59829/Service1.svc";
            string url = @baseurl + "/xpathsearch/?p1=" + xmlPath + "&p2=" + expression;


            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream responseStream = response.GetResponseStream();

            StreamReader reader = new StreamReader(responseStream);
            String json = reader.ReadToEnd();


            result output = processJsonJavaScriptSerializer(json);
            if (output.status.Equals("No Error"))
            {
                string ostr = "Expression Output\n"+ output.value;
                
                TextBox4.Text = ostr;
            }
            else
            {
                TextBox4.Text = "Something Went Wrong in XPath Evaluation";

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
            public String status { get; set; }
            public String errorMsg { get; set; }
            public String value { get; set; }
        }
    }
}