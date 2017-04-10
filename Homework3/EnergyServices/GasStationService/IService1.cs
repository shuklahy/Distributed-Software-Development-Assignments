﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace GasStationService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/getGasStation?lat={latitude}&lon={longitude}")]
         result[] getGasStation(double latitude, double longitude);


        // TODO: Add your service operations here
    }

    [DataContract]
    public class result
    {
        [DataMember]
        public String name { get; set; }

        [DataMember]
        public String openNow { get; set; }

        [DataMember]
        public String address { get; set; }
    }
}
