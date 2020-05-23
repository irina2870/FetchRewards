using System.Collections.Generic;

namespace EmailWebAPI.Classes
{
    // Classes  formatted for processing by email processor
    public class EmailResponse
    {
        public string Email { get; set; }
        public string Count { get; set; }

        public EmailResponse(string email, string count)
        {
            Email = email;
            Count = count;
        }
    }

    public static class ResponseObject
    {
        public static List<EmailResponse> ResponseList { get; set; }

        static ResponseObject()
        {
            ResponseList = new List<EmailResponse>();
        }
    }

}
