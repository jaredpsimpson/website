using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using devfestweekend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace devfestweekend.Pages
{
    public class IndexModel : PageModel
    {
        public IndexModel()
        {
            Speakers = new List<Speaker>();
            Dates = new List<Date>();
        }
        public List<Speaker> Speakers { get; set; }
        public List<Date> Dates { get; set; }

        public void OnGet()
        {
            Speakers = new List<Speaker>
            {
                //new Speaker
                //{
                //    FirstName = "Billy",
                //    LastName = "Hollys",
                //    AvatarUrl = "images/speaker/8.jpg",
                //    Biography = "Elevators!"
                //}
            };

            Dates = new List<Date>
            {
                new Date
                {
                    Href = "https://www.papercall.io/devfestweekend",
                    When = DateTime.Parse("2018-08-17 00:00:00-05:00"),
                    Title = "End of Call for Speakers",
                    CallToAction = "Submit Paper"
                },
                new Date
                {
                    Href = "https://devfestweekend.eventbrite.com/",
                    When = DateTime.Parse("2018-10-13 09:00:00-05:00"),
                    Title = "Irving, TX",
                    CallToAction = "Get Tickets",
                    Address = "7000 State Highway 161, Irving, TX"
                }
            };
        }
    }
}
