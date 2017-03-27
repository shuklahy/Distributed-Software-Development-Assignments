using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Hosting;

namespace WindService
{


    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private static string FILEPATH = HostingEnvironment.ApplicationPhysicalPath + "data\\WindSpeed_10year_data.txt";
        public result WindIntensity(decimal latitude, decimal longitude)
        {
            Console.WriteLine(FILEPATH);
            result r = new result();

            int lat = (int)latitude;
            int lon = (int)longitude;
            decimal avgWindIntensity = (decimal)parseEnergyData(lat, lon, FILEPATH);
            
            if (avgWindIntensity == -1)
            {
                r.status = "Invalid Input";

            }
            else
            {
                r.status = "ok";
            }
            //r.status = FILEPATH;
            r.avgIntensity = avgWindIntensity;

            return r;
        }

        private static decimal parseEnergyData(int lat, int lon, String filepath)
        {
            decimal annualAvg = -1;
            StreamReader reader = File.OpenText(filepath);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] items = line.Split(' ');
                int tempLat = Int32.Parse(items[0]);
                int tempLon = Int32.Parse(items[1]);

                if (tempLat == lat && tempLon == lon)
                {
                    annualAvg = decimal.Parse(items[14]);
                    break;
                }
            }
            return annualAvg;
        }

    }
}
