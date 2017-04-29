using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Hosting;

namespace SolarService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private static string FILEPATH = HostingEnvironment.ApplicationPhysicalPath + "data\\SolarIntensity_20year_data.txt";
        
        public result SolarIntensity(decimal latitude, decimal longitude)
        {
            decimal avgSolarEnergy = 0.0M;
            result r = new result();
            int lat = (int)latitude;
            int lon = (int)longitude;

            avgSolarEnergy = (decimal)parseEnergyData(lat, lon, FILEPATH);
            if (avgSolarEnergy == -1)
            {
                r.status = "Invalid Input";
            }else
            {
                r.status = "Ok";
            }
            r.avgIntensity = avgSolarEnergy;
            return r;
        }

        private static Double parseEnergyData(int lat, int lon, String filepath)
        {
            Double annualAvg = -1;
            StreamReader reader = File.OpenText(filepath);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] items = line.Split(' ');
                int tempLat = Int32.Parse(items[0]);
                int tempLon = Int32.Parse(items[1]);

                if (tempLat == lat && tempLon == lon)
                {
                    annualAvg = Double.Parse(items[14]);
                    break;
                }
            }
            return annualAvg;
        }
    }
}
