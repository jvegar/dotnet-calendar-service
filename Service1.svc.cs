using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Helpers;
using Calendar;
using System.Threading.Tasks;

namespace CalendarService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private static GraphServiceClient graphClient;
        private static CalendarController cal;
        public async Task<String> ScheduleEventAsync(Event e)
        {            
            graphClient = GraphServiceClientProvider.GetAuthenticatedClient();
            cal = new CalendarController(graphClient);
            Microsoft.Graph.Event newevent = await cal.ScheduleEventAsync(e.subject, e.startTime, e.endTime, e.organizerEmail, e.attendeeEmail, e.bodyContent, e.locationName, e.categoryName);
            if (newevent != null) return "OK";
            else return "Error";    
        }
    }
}
