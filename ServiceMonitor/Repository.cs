using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ServiceMonitor
{
    public class Repository
    {
        public static List<ServiceItemDTO> GetDataFromApi()
        {
            List<ServiceItemDTO> newitems = new List<ServiceItemDTO>();

            var credentials = new NetworkCredential(SettingsManager.Username, SettingsManager.Password);
            var handler = new HttpClientHandler { Credentials = credentials };

            using (var client = new HttpClient(handler))
            {
                var url0 = SettingsManager.ApiEndpoint0;
                var url_room = SettingsManager.Room;
                var url1 = SettingsManager.ApiEndpoint1;
                var startDate = DateTime.Now.ToString("yyyy-MM-dd");
                var url2 = SettingsManager.ApiEndpoint2;
                DateTime ed = DateTime.Now.Date;
                var endDate = ed.AddDays(1);
                var url3 = SettingsManager.ApiEndpoint3;

                var url = url0 + url_room + url1 + startDate + url2 + endDate + url3;

                var result = client.GetStringAsync(url).Result;

                var data = JObject.Parse(result);

                int i = 0;

                CultureInfo ci = new CultureInfo("en-US");
                foreach (var item in data["value"])
                {
                    DateTime Start = Convert.ToDateTime((string)data["value"][i]["Start"], ci);
                    DateTime End = Convert.ToDateTime((string)data["value"][i]["End"], ci);

                    DateTime cvStart = Start.Subtract(new TimeSpan(5, 0, 0));
                    DateTime cvEnd = End.Subtract(new TimeSpan(5, 0, 0));

                    DateTime now = DateTime.Now;
                    int compare = DateTime.Compare(cvStart, now);

                    if(compare < 0)
                    {
                        //cvStart is earlier than now. Don't add it to the list. 
                    }
                    else if(compare == 0)
                    {
                        newitems.Add(new ServiceItemDTO()
                        {
                            StartTime = cvStart,
                            EndTime = cvEnd,
                            OrganizerName = (string)data["value"][i]["Organizer"]["EmailAddress"]["Name"]
                        });
                    }
                    else
                    {
                        newitems.Add(new ServiceItemDTO()
                        {
                            StartTime = cvStart,
                            EndTime = cvEnd,
                            OrganizerName = (string)data["value"][i]["Organizer"]["EmailAddress"]["Name"]
                        });
                    }
                    i++;
                }
            }
            return newitems;
        }
    }
}
