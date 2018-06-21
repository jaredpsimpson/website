using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace devfestweekend.Pages
{
    public class IndexModel : PageModel
    {

        public void OnGet()
        {
            //PaperCall = new _EventModel { Title = "Papercall", SubTitle = "Talk Submission Due Date", Date = new DateTime(2018, 8, 13), LinkText = "Submit Talk", LinkUrl = "https://papercall.io" };
        }
    }
}
