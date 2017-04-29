using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WindService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/WindIntensity?lat={latitude}&lon={longitude}")]
        // TODO: Add your service operations here
        result WindIntensity(decimal latitude, decimal longitude);

        
    }

    [DataContract]
    public class result
    {
        [DataMember]
        public decimal avgIntensity { get; set; }

        [DataMember]
        public String status { get; set; }
    }


}
