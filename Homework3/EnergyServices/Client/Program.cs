using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        public static Double parseEnergyData(int lat, int lon, String filepath)
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

        static void Main(string[] args)
        {
            Console.WriteLine("Enter Latitude");
            int lat = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter Longitude");
            int lon = Int32.Parse(Console.ReadLine());

            Double avgSolar = parseEnergyData(lat, lon, "../../data/SolarIntensity_20year_data.txt");
            Double avgWind = parseEnergyData(lat, lon, "../../data/WindSpeed_10year_data.txt");

            //int avgSolar = (int)Double.Parse("-35.52");
            Console.WriteLine("Avg Solar Intensity =" +avgSolar);
            Console.WriteLine("Avg Wind Intensity =" + avgWind);

            Console.WriteLine("Enter any key to Exit");
            Console.Read();
        }
    }
}
