using EmailWebAPI.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace EmailWebAPI.Classes
{
    public class StringFormatRequest : IIncomingRequest
    {
        // input request
        private string PlainString { get; set; }
        public StringFormatRequest(string requestbody)
        {
            PlainString = requestbody;
        }

        public List<string> CreateList => PlainString.Split(',').ToList();
    }
}
