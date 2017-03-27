using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBookingSystem
{
    public class MultiCellBuffer
    {
        private  int SIZE = 3;
        private  SingleCellBuffer[] dataCells ;

        // Index to read & write value from
        private int index;
        public  int totalReads = 0;

        //Producer can go to produce items initially
        static Semaphore write = new Semaphore(3, 3);

        //Consumers should wait until no item is added
        static Semaphore read = new Semaphore(0, 3);

        public MultiCellBuffer()
        {
            dataCells = new SingleCellBuffer[this.SIZE];
            for (int i = 0; i < SIZE; i++)
                this.dataCells[i] = new SingleCellBuffer();

            this.index = 0;
        }

        public String getOneCell()
        {
            String encodedString = "";

            read.WaitOne();

            //Decrement index atomically
            Interlocked.Decrement(ref this.index);
            int copy = this.index;

            //Copy is maintained basically for each thread
            lock (dataCells[copy]) {
                Console.WriteLine("Reading from buffer at index :" + copy);
                encodedString = dataCells[copy].getCell();
                this.totalReads++;
            }
            write.Release();
                
            return encodedString;
        }

        public  void setOneCell(string encodedstr)
        {
            write.WaitOne();

            //Increment index Automatically
            Interlocked.Increment(ref this.index);

            //copy is basically maitained for each thread
            int copy = this.index;
            lock (dataCells[copy-1])
            {
                Console.WriteLine("Writing to buffer at index : " + (copy-1));
                dataCells[copy-1].setCell(encodedstr);
            }
            read.Release();

        }
    }
}
