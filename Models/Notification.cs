using System;

namespace devfestweekend.Models
{
    public class Notification : BaseDataObject
    {
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}

