using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace restFullData
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public TextMessage welcome(string yourName)
        {
            TextMessage message = new TextMessage();
            message.Message = string.Format("welcome to REST {0}", yourName);
            return message;
        }

        public TextMessage Welcome(string yourName)
        {
            TextMessage message = new TextMessage();
            message.Message = string.Format("welcome to REST {0}", yourName);
            return message;
        }

        public personInfo setNameAge(string n, int a)
        {
            personInfo p = new personInfo();
            p.name = n;
            p.age = a;
            return p;
        }

        public personInfo setNameAgeJson(string n, string a)
        {
            personInfo p = new personInfo();
            p.name = n;
            p.age = Int32.Parse(a);
            return p;
        }
        public string set(string n)
        {
            personInfo p = new personInfo();
            p.name = n;
            p.age = 10;
            return p.name;
        }

        
    }
}
