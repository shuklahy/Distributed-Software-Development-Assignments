using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Hw4Part2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/validate/?p1={xmlPath}&p2={xsdPath}")]
        result verification(string xmlPath, string xsdPath);


        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/xpathsearch/?p1={xmlPath}&p2={expression}")]
        result XPathSearch(string xmlPath, string expression);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class result
    {
        [DataMember]
        public String status { get; set; }

        [DataMember]
        public String errorMsg { get; set; }

        [DataMember]
        public String value { get; set; }

    }
}
