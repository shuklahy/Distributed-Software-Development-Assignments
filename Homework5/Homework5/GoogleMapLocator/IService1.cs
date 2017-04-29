using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace GoogleMapLocator
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/getMapURL?lat={latitude}&lon={longitude}")]
        result getMapURL(double latitude, double longitude);

    }


    [DataContract]
    public class result
    {
        [DataMember]
        public String url { get; set; }

        [DataMember]
        public String status { get; set; }

    }
}
