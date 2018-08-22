using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using devfestweekend.Models;
using devfestweekend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace devfestweekend.Pages
{
    public class ScheduleModel : PageModel
    {
        private DataService dataService = new DataService();
        public List<FeaturedEvent> Events { get; set; }
        public List<Session> Sessions { get; set; }

        public async Task OnGet()
        {
            Events = await dataService.GetEventsAsync();
            Sessions = await dataService.GetSessionsAsync();
        }
    }
}