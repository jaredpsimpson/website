using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Text.RegularExpressions;

namespace devfestweekend.Pages
{
    public class ContactModel : PageModel
    {
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]        
        public string Email { get; set; }
        [BindProperty]
        public string Subject { get; set; }
        [BindProperty]
        public string Message { get; set; }

        public bool MessageSent { get; set; } = false;

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                await Task.Delay(1);
                Console.WriteLine ($"Hello {Name}, How are you doing?  I see you're emailing me about {Subject}: {Message}.  I will reply to {Email}");
                var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
                var receiverAddress = Environment.GetEnvironmentVariable("RECEIVER_EMAIL_ADDRESS");
                var client = new SendGridClient(apiKey);

                var htmlTags = new Regex("<(^>)*>");

                var htmlBannedMessage = htmlTags.Replace(Message, string.Empty);
                var htmlBannedSubject = htmlTags.Replace(Subject, string.Empty);

                var sender = new EmailAddress(Email, Name);
                var receiver = new EmailAddress(receiverAddress, "Dev Fest Weekend - Contact Us");

                var message = MailHelper.CreateSingleEmail(sender, receiver,
                    "Dev Fest Weekend - Contact Us Form",
                    $"You have been sent an email from {Name}: {Email}\r\nSubject: {Subject}\r\nBody:  {Message}",
                    $"You have been sent an email from {Name}: {Email}\r\nSubject: {htmlBannedMessage}\r\nBody:  {htmlBannedMessage}"
                );

                await client.SendEmailAsync(message);

                MessageSent = true;
            }

            return Page();
        }
    }
}
