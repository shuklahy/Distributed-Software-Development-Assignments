using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace restFullData
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        [WebGet(ResponseFormat =WebMessageFormat.Json,
        UriTemplate="/welcome/{yourName}")]
        TextMessage welcome(string yourName);

      
        [OperationContract]
        [WebInvoke(Method="GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/setNameAge?n={n}&a={a}")]
        personInfo setNameAge(string n, int a);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/setNameAgeJson/{n}/{a}")]
        personInfo setNameAgeJson(string n, string a);

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json, UriTemplate = "/set/{name}")]
        string set(string name);


    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class TextMessage
    {
        [DataMember]
        public string Message { get;set; }
    }

    [DataContract]
    public class personInfo
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public int age { get; set; }
    }


}
