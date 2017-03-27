using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfServiceHomework1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private Random random;

        public string password(string firstName, string lastName, int age)
        {
            //Password should be the first two letters of the last name + 
            //last two letters of the first name +age mod 5

            String pass = "";

            pass += lastName.Substring(0, 2);
            pass += firstName.Substring(firstName.Length - 2, 2);
            int ageMod = age % 5;
            pass += ageMod.ToString();

            return pass;

        }


        public int loginId(int age)
        {
            //Login ID should be a number and is equal to age*(randomly generated number between 100 – 200)
            
            random = new Random();
            return age * random.Next(100, 200); 
        }
    }
}
