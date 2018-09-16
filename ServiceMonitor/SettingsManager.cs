using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceMonitor
{
    public class SettingsManager
    {
        public static string ApiEndpoint0 = "https://outlook.office365.com/api/v1.0/users/";
        public static string Room = ConfigurationManager.AppSettings["Room"];
        public static string ApiEndpoint1 = "/calendarview?startDateTime=";
        public static string ApiEndpoint2 = "&endDateTime=";
        public static string ApiEndpoint3 = "&$select=Subject,Start,End,Organizer";
        public static string Username = ConfigurationManager.AppSettings["Username"];
        public static string Password = ConfigurationManager.AppSettings["Password"];
    }
}
