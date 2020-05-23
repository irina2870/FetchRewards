using EmailWebAPI.Classes;
using EmailWebAPI.Components;
using EmailWebAPI.Controllers;
using System.Collections.Generic;
using Xunit;

namespace EmailWebAPI.Test
{
    public class UnitTest
    {

        [Fact]
        public void StringRequest()
        {
            ResponseObject.ResponseList = new List<EmailResponse>();
            List<List<string>> testSet = new List<List<string>>() { new List<string> { "irinafimov@gmail.com", "3" }, new List<string> { "irinafimov@hotmail.com", "1" } };
            string request = "irina.fimov@gmail.com,irina-fimov@gmail.com,irinafimov@gmail.com,irina.fimov@hotmail.com";

            var controller = new EmailAPI();


            StringFormatRequest stringRequest = new StringFormatRequest(request);
            EmailProcessor.CountEmails(stringRequest.CreateList);

            for (int i = 0; i < ResponseObject.ResponseList.Count; i++)
            {
                Assert.Equal(ResponseObject.ResponseList[i].Email, testSet[i][0]);
                Assert.Equal(ResponseObject.ResponseList[i].Count, testSet[i][1]);
            }
        }

        [Fact]
        public void SJSONRequest()
        {
            ResponseObject.ResponseList = new List<EmailResponse>();
            List<List<string>> testSet = new List<List<string>>() { new List<string> { "irinafimov@gmail.com", "3" }, new List<string> { "irinafimov@hotmail.com", "1" } };
            string request = "{\"EmailList\":[{\"Email\":\"irina.fimov@gmail.com\"},{\"Email\":\"irina-fimov@gmail.com\"},{\"Email\":\"irinafimov@gmail.com\"},{\"Email\":\"irina.fimov@hotmail.com\"}]}";

            JSONFormatRequest jsonRequest = new JSONFormatRequest(request);
            EmailProcessor.CountEmails(jsonRequest.CreateList);


            for (int i = 0; i < ResponseObject.ResponseList.Count; i++)
            {
                Assert.Equal(ResponseObject.ResponseList[i].Email, testSet[i][0]);
                Assert.Equal(ResponseObject.ResponseList[i].Count, testSet[i][1]);
            }

        }
    }
}
