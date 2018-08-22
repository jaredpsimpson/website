using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using devfestweekend.Models;
using devfestweekend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace devfestweekend.Pages
{
    public class SpeakersModel : PageModel
    {
        private DataService dataService = new DataService();
        public List<Speaker> Speakers { get; set; }

        public async Task OnGet()
        {
            var sessions = await dataService.GetSessionsAsync();

            Speakers = sessions
                    .Select(s => s.Speakers.First())
                    .Distinct()
                    .OrderBy(s => Guid.NewGuid())
                    .ToList();

            Speakers.ForEach(speaker =>
            {
                speaker.Sessions = sessions
                        .Where(session => session.Speakers.Any(s => s.Id == speaker.Id))
                        .ToList();
            });
        }
    }
}