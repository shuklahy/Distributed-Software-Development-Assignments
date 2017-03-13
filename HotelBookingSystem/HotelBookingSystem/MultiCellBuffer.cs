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
        private  String[] dataCells = new String[3];
        private  int tail = 0;
        private  int head = 0;
        private  int bufferEleCount = 0;
        public   int totalReads = 0;

        private Object []cellLocks = new Object[3]; //Locks for individual Thread
        
        static Semaphore write = new Semaphore(3, 3);
        static Semaphore read = new Semaphore(1, 1);

        public MultiCellBuffer()
        {
            //Initialize Lock Objects
            for (int i=0; i<SIZE; i++)
            {
                cellLocks[i] = new Object();
            }
        }

       public  String getOneCell()
       {
            String encodedString = "";
            
            //Logic to get cell from buffer
            read.WaitOne(); //This is as good as Mutual Exclusion

            
            //Only Lock cell for which the thread is reading
            lock (this)
            {

                while (bufferEleCount == 0)
                    Monitor.Wait(this);
                head = (head + 1) % SIZE;
                //Thread.Sleep(1000);
                Console.WriteLine("Reading from buffer at index :"+head);
                
                encodedString = dataCells[head];
                bufferEleCount--;
                this.totalReads++;
                read.Release();
                Monitor.PulseAll(this);
            }

            return encodedString;
        }

        public  void setOneCell(string encodedstr)
        {
            write.WaitOne();

            //Lock to get cell number to get lock of
            lock (this)
            {
                tail = (tail + 1) % SIZE;
            }

            //lock on individual cell
            lock (this)
            {                

                while(bufferEleCount == SIZE)
                {
                    Monitor.Wait(this);
                }
                Console.WriteLine("Writing to buffer at index : " + tail);
                dataCells[tail] = encodedstr;
                bufferEleCount++;
                write.Release();
                Monitor.Pulse(this);
            }    
        }
    }
}
