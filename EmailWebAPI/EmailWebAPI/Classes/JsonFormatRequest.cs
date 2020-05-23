using EmailWebAPI.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace EmailWebAPI.Classes
{
    public class JSONFormatRequest : IIncomingRequest
    {
        // input request
        private string JSONString { get; set; }
        public JSONFormatRequest(string requestbody) => JSONString = requestbody;


        public List<string> CreateList
        {
            get
            {
                var result = JsonConvert.DeserializeObject<RootObject>(JSONString);
                return result.EmailList.Select(p => p.Email).ToList();
            }
        }
    }
}
