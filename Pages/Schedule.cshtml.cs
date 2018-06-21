using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using devfestweekend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace devfestweekend.Pages
{
    public class ScheduleModel : PageModel
    {
        public List<FeaturedEvent> Events { get; set; }
        public List<Session> Sessions { get; set; }

        //private const string BaseAddress = "https://confdfw.azurewebsites.net/tables";
        private const string BaseAddress = "http://localhost:51800/tables/";
        private HttpClient client;

        public ScheduleModel()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Add("ZUMO-API-VERSION", "2.0.0");
            client.BaseAddress = new Uri(BaseAddress);
        }

        public async Task OnGet()
        {
            await SetEvents();
            await SetSessions();
        }

        public async Task SetEvents()
        {
            try
            {
                var message = new HttpRequestMessage(HttpMethod.Get, "featuredEvent");

                var response = await client.SendAsync(message);

                var json = await response.Content.ReadAsStringAsync();

                Events = JsonConvert.DeserializeObject<List<FeaturedEvent>>(json);
            }
            catch (Exception exception)
            {
                Debug.WriteLine("");
            }
        }

        private async Task SetSessions()
        {
            try
            {
                var message = new HttpRequestMessage(HttpMethod.Get, "session");

                var response = await client.SendAsync(message);

                var json = await response.Content.ReadAsStringAsync();

                Sessions = JsonConvert.DeserializeObject<List<Session>>(json);
            }
            catch (Exception exception)
            {
                Debug.WriteLine("");
            }
        }
    }
}