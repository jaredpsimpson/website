using devfestweekend.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace devfestweekend.Services
{
    public class DataService
    {
        private const string BaseAddress = "https://confdfw.azurewebsites.net/tables/";
        //private const string BaseAddress = "http://localhost:51800/tables/";
        private HttpClient client;

        public DataService()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Add("ZUMO-API-VERSION", "2.0.0");
            client.BaseAddress = new Uri(BaseAddress);
        }

        public async Task<List<FeaturedEvent>> GetEventsAsync()
        {
            try
            {
                var message = new HttpRequestMessage(HttpMethod.Get, "featuredEvent");

                var response = await client.SendAsync(message);

                var json = await response.Content.ReadAsStringAsync();

                var events = JsonConvert.DeserializeObject<List<FeaturedEvent>>(json);

                return events;
            }
            catch (Exception exception)
            {
                Debug.WriteLine("");
                return new List<FeaturedEvent>();
            }
        }

        public async Task<List<Session>> GetSessionsAsync()
        {
            try
            {
                var message = new HttpRequestMessage(HttpMethod.Get, "session");

                var response = await client.SendAsync(message);

                var json = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<Session>>(json);
            }
            catch (Exception exception)
            {
                Debug.WriteLine("");
                return new List<Session>();
            }
        }
        
        public async Task<List<Sponsor>> GetSponsorsAsync()
        {
            try
            {
                var message = new HttpRequestMessage(HttpMethod.Get, "sponsor");

                var response = await client.SendAsync(message);

                var json = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<Sponsor>>(json);
            }
            catch (Exception exception)
            {
                Debug.WriteLine("");
                return new List<Sponsor>();
            }
        }
    }
}
