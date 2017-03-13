using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using HotelBookingSystem;

namespace HotelBookingSystem
{
    public delegate void priceCutDelegate(HotelSupplier hs);
    public delegate void orderConfirmedDelegate(OrderClass obj);

    class Program
    {
        public static int noOfPriceCutEvents = 5; //Determines the number of Events hotelsupplier should emit 
        public static int hsCount = 2; // Number of Hotel supplier : change this to increase HS
        public static int taCount = 5; // Number of Travel Agency : Change this to increase TA

        public static String key = "ABCDEFGHIJKLMNOP";
        public static MultiCellBuffer mcb = new MultiCellBuffer();
        public static TravelAgency[] ta = null;
        public static HotelSupplier[] hs = null;
        public static List<Thread> l1 = new List<Thread>();

        static void Main(string[] args)
        {

            
            Console.WriteLine("Hotel Booking System");

            hs = new HotelSupplier[hsCount];
            ta = new TravelAgency[taCount];
            Thread[] hst = new Thread[hsCount];
            //Create Hotel Supplier
            for(int i=0; i<hsCount; i++)
            {
                hs[i] = new HotelSupplier(i + 1);
            }

            //create Travel Agencies
            for(int i=0; i<taCount; i++)
            {
                ta[i] = new TravelAgency(i + 1, 5000 + i * 2);
            }


            // Register travel agencies for priceCut and orderConfirm Events
            for(int i=0; i<hsCount; i++)
            {
                for(int j=0; j<taCount; j++)
                {
                    hs[i].priceCut += new priceCutDelegate(ta[j].placeOrder);
                }
            }

            // Start pricing models for all hotel suppliers and this starts the overall program
            for(int i=0; i<hsCount; i++)
            {
                hst[i] = new Thread(new ThreadStart(hs[i].PricingModel));
                hst[i].Start();
                l1.Add(hst[i]);
            }

            Thread dispatcher = new Thread(new ThreadStart(HotelSupplier.receiveOrder));
            dispatcher.Start();
            l1.Add(dispatcher);

            
            //wait for all threads to complete
            for(int i=0; i<l1.Count; i++)
            {
                l1[i].Join();
            }

            Console.WriteLine("***************\n Done With Booking \n [Note This ensures that the program will Exit "+
                "after some of remaining threads complete execution]\n*************************");
            Console.Read();

        }
    }
}
