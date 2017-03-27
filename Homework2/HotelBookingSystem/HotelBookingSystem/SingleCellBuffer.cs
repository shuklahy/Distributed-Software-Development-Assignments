using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem
{
    /*
     * The Rationale of using this class is that we can have lock
     * on individual cell independently
     */

    class SingleCellBuffer
    {
        private String encodedString;

        public String getCell()
        {  
            return this.encodedString;
         }

        public void setCell(String str)
        {
            this.encodedString = str;
        }
    }
}
