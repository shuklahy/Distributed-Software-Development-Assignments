using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Net.Http;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public locationObject GetLatLon(string zipcode)
        {
            //AIzaSyBvpxAcBerMsj8vWYcJDDzla0X1nWA8GsY
            locationObject returnObject;
            string url = @"https://maps.googleapis.com/maps/api/geocode/json?address=" + zipcode + "&key=AIzaSyBvpxAcBerMsj8vWYcJDDzla0X1nWA8GsY";
            Console.WriteLine(url);


            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream responseStream = response.GetResponseStream();

            StreamReader reader = new StreamReader(responseStream);
            String json = reader.ReadToEnd();
            returnObject = processJsonJavaScriptSerializer(json);

            Console.WriteLine("\n");
            Console.WriteLine(json);

            return returnObject;
        }

        public locationObject processJsonJavaScriptSerializer(String data)
        {
            GoogleGeoCodeResponse locationDetails = JsonConvert.DeserializeObject<GoogleGeoCodeResponse>(data);
            Console.WriteLine(locationDetails.results[0].geometry.location.lat);
            var answer = new locationObject
            {
                latitude = Convert.ToDouble(locationDetails.results[0].geometry.location.lat),
                longitude = Convert.ToDouble(locationDetails.results[0].geometry.location.lng),
                placeId = locationDetails.results[0].place_id
            };
            return answer;
        }

        public class GoogleGeoCodeResponse
        {

            public string status { get; set; }
            public results[] results { get; set; }

        }

        public class results
        {
            public string formatted_address { get; set; }
            public geometry geometry { get; set; }
            public string[] types { get; set; }
            public string place_id { get; set; }
            public address_component[] address_components { get; set; }
        }

        public class geometry
        {
            public string location_type { get; set; }
            public location location { get; set; }
        }

        public class location
        {
            public string lat { get; set; }
            public string lng { get; set; }
        }

        public class address_component
        {
            public string long_name { get; set; }
            public string short_name { get; set; }
            public string[] types { get; set; }
        }
    }
}
