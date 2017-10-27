using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace devfestweekend.Pages
{
    public class _EventModel : PageModel
    {
        public DateTime Date { get; set; }
        public string Title { get; set; } 
        public string SubTitle { get; set; }
        public string LinkText { get; set; }
        public string LinkUrl { get; set; }
    }
}