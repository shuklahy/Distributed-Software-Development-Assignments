using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace GoogleMapLocator
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public result getMapURL(double latitude, double longitude)
        {
            result r = new result();
            String API_KEY = "XXXXXXX";

            r.status = "OK";

            String base_url = "https://maps.googleapis.com/maps/api/staticmap?center=" + latitude + "," + longitude + "&zoom=15&size=600x300&maptype=roadmap";
            String marker = "markers=color:blue%7Clabel:S%7C" + latitude + "," + longitude;
            String key = "key=" + API_KEY;

            String final_url = base_url + "&" + marker + "&" + key;
            r.url = final_url;

            return r;
        }
    }
}
