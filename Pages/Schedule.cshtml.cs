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
        public List<RoomSessions> Tracks { get; set; }
        public List<string> Tabs { get; set; }
            = new List<string>
            {
                "two",
                "three",
                "four",
                "five",
                "six",
                "seven"
            };

        public async Task OnGet()
        {
            var sessions = await dataService.GetSessionsAsync();
            var rooms = sessions.Select(s => s.Room).Distinct(new RoomComparer());

            sessions = sessions.OrderBy(s => s.Room.Id).ThenBy(s => s.StartTime).ToList();

            Events = await dataService.GetEventsAsync();
            Tracks = (from session in sessions
                      group session by session.Room.Id into track
                      select new RoomSessions
                      {
                        Room = rooms.First(r => r.Id == track.Key),
                        Sessions = track.ToList()
                      }).ToList();
        }
    }

    public class RoomSessions
    {
        public Room Room { get; set; }
        public List<Session> Sessions { get; set; }
    }

    public class RoomComparer : IEqualityComparer<Room>
    {
        public bool Equals(Room x, Room y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(Room obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}