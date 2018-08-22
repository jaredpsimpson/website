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
                new Speaker
                {
                    FirstName = "Billy",
                    LastName = "Hollis",
                    AvatarUrl = "images/speaker/billy-hollis.jpg",
                    Biography = "Billy Hollis is a UX designer and application developer from Nashville, Tennessee. He leads a team with a worldwide reputation for designing and developing innovative, compelling user experiences. He has written many books and articles, and speaks at conferences around the world on user experience, design thinking, and native application technologies. Billy also spends time onsite for companies of all sizes, teaching teams about UX design, and collaborating with them on designing a new generation of their application.",
                    TwitterUrl = "https://twitter.com/billyhollis"
                },
                new Speaker
                {
                    FirstName = "Troy",
                    LastName = "Hunt",
                    AvatarUrl = "images/speaker/troy-hunt.jpg",
                    Biography = "Troy is a Microsoft Regional Director and MVP, Pluralsight author and world-renowned internet security specialist. He spends his time teaching developers how to break into their own systems before helping to piece them back together to be secure against today’s online threats. He’s also the creator of “Have I Been Pwned”, the free online service for breach monitoring and notifications. Troy regularly blogs at troyhunt.com from his home in Australia.",
                    TwitterUrl = "https://twitter.com/troyhunt"
                }
            };

            Dates = new List<Date>
            {
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
