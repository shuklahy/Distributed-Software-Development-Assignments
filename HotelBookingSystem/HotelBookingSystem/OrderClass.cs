using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem
{
    public class OrderClass
    {
        private int senderId; //TravelAgency Id
        private int cardNo; 
        private int receiverId; // HotelSupplier ID
        private int amount;  // No of room to order
        private string timestamp;
       
        public OrderClass(int senderId, int cardNo, int receiverId, int amount, string timestamp)
        {
            this.senderId = senderId;
            this.cardNo = cardNo;
            this.receiverId = receiverId;
            this.amount = amount;
            this.timestamp = timestamp;
        }

        public override string ToString()
        {
            return "Order: TA-[" + senderId + "] CCno-" + cardNo + " HS-[" + receiverId + "] A-"+ amount + " Time-" + timestamp + " TotalReads-"+Program.mcb.totalReads;
        }

        public string Timestamp
        {
            get { return timestamp; }
            set { timestamp = value; }
        }
        public int SenderId
        {
            get { return senderId; }
            set { senderId = value; }
        }


        public int CardNo
        {
            get { return cardNo;  }
            set { cardNo = value; }
        }


        public int ReceiverId
        {
            get { return receiverId;  }
            set { receiverId = value; }
        }

        public int Amount
        {
            get { return amount;  }
            set { amount = value; }
        }
    }
}
