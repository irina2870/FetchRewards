using EmailWebAPI.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmailWebAPI.Components
{
    public class EmailProcessor
    {
        public static List<EmailResponse> CountEmails(List<string> request)
        {
            List<string> cleanEmails = new List<string>();
            request.ForEach(delegate (string email)
            {
                List<string> emailSplits = email.Split('@').ToList();
                cleanEmails.Add(String.Format("{0}@{1}", System.Text.RegularExpressions.Regex.Replace(emailSplits[0], "[^0-9a-zA-Z]", ""), emailSplits[1]));
            });

            List<EmailResponse> tempList = (from email in cleanEmails
                                            group email by email into emailGroup
                                            select new EmailResponse(emailGroup.Key, emailGroup.Count().ToString())).ToList();


            ResponseObject.ResponseList.AddRange(tempList);
            var jsonObj = JsonConvert.SerializeObject(ResponseObject.ResponseList);
            return ResponseObject.ResponseList;
        }
    }
}

