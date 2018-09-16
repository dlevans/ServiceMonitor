using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Configuration;
using Newtonsoft.Json.Linq;

namespace ServiceMonitor
{
    public class ServiceItemDTO
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string OrganizerName { get; set; }
    }
}