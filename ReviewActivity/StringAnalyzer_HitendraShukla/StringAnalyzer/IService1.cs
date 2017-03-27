using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace StringAnalyzer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        // TODO: Add your service operations here
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/analyze/{inputstr}")]
        StringDetailsClass Analyze(string inputstr);
        
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class StringDetailsClass
    {
        int digitCount = 0;
        int upperCaseCount = 0;
        int lowerCaseCount = 0;

        [DataMember]
        public int DigitCount
        {
            get { return digitCount;  }
            set { digitCount = value;  }

        }

        [DataMember]
        public int UpperCaseCount
        {
            get { return upperCaseCount;  }
            set { upperCaseCount = value; }
        }

        [DataMember]
        public int LowerCaseCount
        {
            get { return lowerCaseCount; }
            set { lowerCaseCount = value; }
        }
        
    }
}
