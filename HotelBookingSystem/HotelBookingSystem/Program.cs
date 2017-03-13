﻿/*
 * @author : Hitendra Shukla
 * ASU ID : 1211175859
 * Project : Hotel Booking System Using Threads
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using HotelBookingSystem;
/*
 * NOTE: I have set price cut event to 5 you can set it to any value
 * For higher values though the program will stuck since I have used random function for pricing model
 * and in case of higher cutoff the price sometimes hits 0 which is min value and since no other min value can
 * generated no new pricecut events will be generated and Hotel supplier will go on forever
 */
namespace HotelBookingSystem
{
    public delegate void priceCutDelegate(HotelSupplier hs);
    
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

            // Dispatcher Thread:  THis thread is responsible for reading from buffer and deliverying order to Hotel supplier Object
            // Hotel supplier will then spawn new thread to process this order
            Thread dispatcher = new Thread(new ThreadStart(HotelSupplier.receiveOrder));
            dispatcher.Start();
            l1.Add(dispatcher);

            
            //wait for all threads to complete
            for(int i=0; i<l1.Count; i++)
            {
                l1[i].Join();
            }

            Console.WriteLine("***************\n Done With Booking \n *************************");

            Console.WriteLine();
            Console.WriteLine("Press Any Key to Exit");

            Thread.Sleep(2000);
            Console.Read();

        }
    }
}