using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace StringAnalyzer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        
        public StringDetailsClass Analyze(string inputstr)
        {
            int dcount = 0;
            int upper = 0;
            int lower = 0;

            foreach(char c in inputstr)
            {
                if (Char.IsDigit(c))
                {
                    dcount += 1;

                }else if (Char.IsUpper(c))
                {
                    upper += 1;

                }else if (Char.IsLower(c))
                {
                    lower += 1;
                }
            }
            var response = new StringDetailsClass
            {
                DigitCount = dcount,
                LowerCaseCount = lower,
                UpperCaseCount = upper
            };
            return response;

        }
    }
}
