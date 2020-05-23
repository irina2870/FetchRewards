using System.Collections.Generic;

namespace EmailWebAPI.Classes
{
    // Original requests
    public class EmailRequest
    {
        public string Email { get; set; }
    }

    public class RootObject
    {
        public List<EmailRequest> EmailList { get; set; }
    }
}
