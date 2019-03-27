using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace CalendarService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        [WebInvoke(UriTemplate = "/ScheduleEventAsync",
                  Method = "POST",
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json)]
        Task<String> ScheduleEventAsync(Event e);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Event
    {
        //string subject, string startTime, string endTime, string attendeeEmail
        [DataMember]
        public string subject { get; set; }
        [DataMember]
        public string startTime { get; set; }
        [DataMember]
        public string endTime { get; set; }
        [DataMember]
        public string organizerEmail { get; set; }
        [DataMember]
        public string attendeeEmail { get; set; }        
        [DataMember]
        public string bodyContent { get; set; }
        [DataMember]
        public string locationName { get; set; }
        [DataMember]
        public string categoryName { get; set; }
    }
}
