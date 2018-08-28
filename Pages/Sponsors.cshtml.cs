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
    public class SponsorsModel : PageModel
    {
        private DataService dataService = new DataService();
        public List<GroupedSponsorLevels> GroupedSponsorLevels { get; set; }
        public async Task OnGetAsync()
        {
            var sponsors = await dataService.GetSponsorsAsync();

            GroupedSponsorLevels = (from s in sponsors
                                    group s by s.SponsorLevel into g
                                    select new GroupedSponsorLevels
                                    {
                                        SponsorLevel = g.Key, Sponsors = g.ToList()
                                    }).ToList();
        }
    }

    public class GroupedSponsorLevels
    {
        public SponsorLevel SponsorLevel { get; set; }
        public List<Sponsor> Sponsors { get; set; }
    }

}