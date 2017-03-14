using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem
{
    class TravelAgency
    {
        private int senderId;
        private int amount;
        private int cardNo;
        

        public TravelAgency(int id, int cardNo)
        {
            this.senderId = id;
            this.cardNo = cardNo;
        }
        public void placeOrderUsingTravelAgencyThread(HotelSupplier hs)
        {
            Random rand = new Random();
            this.amount =  rand.Next(1, 500 - hs.Price);

            OrderClass o = new OrderClass(this.senderId, this.cardNo, hs.ReceiverId, this.amount, hs.Price, DateTime.Now.ToString());
            String encodedString = Encoder.encode(o, Program.key);

            // put this string into buffer
            Program.mcb.setOneCell(encodedString);
        }

        public void placeOrder(HotelSupplier hs)
        {
            Thread t = new Thread(() => this.placeOrderUsingTravelAgencyThread(hs));
            t.Start();
            
        }


        public void receiveConfirmation(OrderClass obj)
        {
            Console.WriteLine("Printing Confirmation at Travel Agency : " + obj.ToString());
            Console.WriteLine("Time of Order Confirmation = " +  DateTime.Now +"\n------------");
        }
    }
}
