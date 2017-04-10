using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Script.Serialization;

namespace GasStationService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        String API_KEY = "AIzaSyBLR-5Nq0RFRvIy5Qz6Pqqd8CEtncfzeq8";

        result[] IService1.getGasStation(double latitude, double longitude)
        {
            
            //Show gas station within 5000 m in URL
            String baseurl = "https://maps.googleapis.com/maps/api/place/nearbysearch/json?";
            String url = @baseurl + "location=" + latitude + "," + longitude + "&radius=5000&type=gas_station&key=" + API_KEY;


            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream responseStream = response.GetResponseStream();

            StreamReader reader = new StreamReader(responseStream);
            String json = reader.ReadToEnd();

            Console.WriteLine(json);

            RootObject jsonRoot = processJsonJavaScriptSerializer(json);

            result[] res = new result[jsonRoot.results.Count];
            for (int i=0; i<jsonRoot.results.Count; i++)
            {
                String name = jsonRoot.results[i].name;
                String address = jsonRoot.results[i].vicinity;
                String openNow = "";
                if (jsonRoot.results[i].opening_hours!=null && jsonRoot.results[i].opening_hours.open_now)
                {
                    openNow = "Yes";
                }
                else
                {
                    openNow = "No";
                }

                res[i] = new result();
                res[i].name = name;
                res[i].address = address;
                res[i].openNow = openNow;
            }
                

   
            return res;
        }

        static RootObject processJsonJavaScriptSerializer(String data)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            RootObject r = js.Deserialize<RootObject>(data);
            return r;
        }



        public class Location
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class Northeast
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class Southwest
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class Viewport
        {
            public Northeast northeast { get; set; }
            public Southwest southwest { get; set; }
        }

        public class Geometry
        {
            public Location location { get; set; }
            public Viewport viewport { get; set; }
        }

        public class Photo
        {
            public int height { get; set; }
            public List<string> html_attributions { get; set; }
            public string photo_reference { get; set; }
            public int width { get; set; }
        }

        public class OpeningHours
        {
            public bool open_now { get; set; }
            public List<object> weekday_text { get; set; }
        }

        public class Result
        {
            public Geometry geometry { get; set; }
            public string icon { get; set; }
            public string id { get; set; }
            public string name { get; set; }
            public List<Photo> photos { get; set; }
            public string place_id { get; set; }
            public double rating { get; set; }
            public string reference { get; set; }
            public string scope { get; set; }
            public List<string> types { get; set; }
            public string vicinity { get; set; }
            public OpeningHours opening_hours { get; set; }
            public int? price_level { get; set; }
        }

        public class RootObject
        {
            public List<object> html_attributions { get; set; }
            public List<Result> results { get; set; }
            public string status { get; set; }
        }

    }
}
