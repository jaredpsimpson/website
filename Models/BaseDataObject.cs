using System;

#if BACKEND
using Microsoft.Azure.Mobile.Server;
#elif MOBILE
using MvvmHelpers;
#endif

namespace devfestweekend.Models
{

    public interface IBaseDataObject
    {
        string Id {get;set;}
    }

    public class BaseDataObject : IBaseDataObject
    {
        public BaseDataObject()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string RemoteId { get; set; }

        [Newtonsoft.Json.JsonProperty("Id")]
        public string Id { get; set; }
        
    }
}

