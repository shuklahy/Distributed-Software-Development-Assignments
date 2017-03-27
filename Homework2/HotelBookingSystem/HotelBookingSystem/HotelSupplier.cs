using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace HotelBookingSystem
{
    public class HotelSupplier
    {

        // This should contain method for Order Processing
        private int price;
        private Random random;
        private int receiverId;
        private int cnt;
        private double tax;
        private double locationCharge;
        // Event for Hotel Supplier
        public event priceCutDelegate priceCut;
        

        public HotelSupplier(int receiverId)
        {
            this.price = Int32.MaxValue; 
            this.random = new Random();
            this.receiverId = receiverId;
            this.cnt = 0;
            this.tax = (this.receiverId + 1) * 3;
            this.locationCharge = (this.receiverId + 1) * 5; 
        }


        public int ReceiverId
        {
            get { return receiverId; }
            set { receiverId = value; }
        }


        public int Price
        {
            get { return price; }
            set { price = value;}
        }
        // Pricing Model
        public void PricingModel()
        {
            Console.WriteLine("Pricing model for " + this.receiverId + " started");
            while (true) {

                if (this.cnt == Program.noOfPriceCutEvents)
                {
                    break;
                }
                    

                int curPrice = this.random.Next(0,500);
                if(curPrice < this.price)
                {
                    if (curPrice == 0)
                    {
                        this.price = 250; 
                        //This is just a way to make sure that the threads don't go to pending state
                        // if minPrice is achieved before total number of price Cut Events 
                    }
                    else
                    {

                        this.price = curPrice;
                        Console.WriteLine("\n************ {{EVENT}} Price Reduced for HS-" + this.ReceiverId + " New Price=" + this.price + "*****************\n");
                        //Emit priceCut Event to Travel Agencies
                        this.priceCut(this);
                        this.cnt++;
                    }
                }

            }
            Console.WriteLine("\n*** ThreadALERT : Stopping Hotel Supplier Thread"+this.ReceiverId +"\n");            
        }

        // Call this when you receive order from Multicell Buffer
        public void OrderProcessing(OrderClass obj)
        {
            Console.WriteLine("Hotel Supplier "+ this.receiverId+" is processing Order");
            if (obj.CardNo < 5000 && obj.CardNo > 7000)
            {
                Console.WriteLine("Invalid card number bailing out");
            }else
            {
                double totalcost = obj.UnitPriceOfRoom * obj.Amount + this.tax + this.locationCharge;
                //send confirmation to Travel Agency
                Console.WriteLine("Order Processed by Hotel Supplier :" + this.receiverId + " for Travel Agency: " + obj.SenderId + " TotalPrice:" +totalcost +" UnitsBooked:"+obj.Amount);
                Program.ta[obj.SenderId - 1].receiveConfirmation(obj);
            }
        }


        
        public static void receiveOrder() {

            while (Program.mcb.totalReads < (Program.noOfPriceCutEvents*Program.taCount*Program.hsCount)) {

                String orderStr = Program.mcb.getOneCell();
                OrderClass order = Decoder.decode(orderStr, Program.key);
                Thread thread = new Thread(() => Program.hs[order.ReceiverId - 1].OrderProcessing(order));
                thread.Start();
            }

            Console.WriteLine("*** ThreadALERT : Stopping Dispatcher Thread");
        }

    }
}
