using EmailWebAPI.Classes;
using EmailWebAPI.Components;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EmailWebAPI.Controllers
{
    public class EmailAPI : ControllerBase
    {
        [HttpPost]
        [Route("api/BodyTypes/PlainStringBody")]
        public JsonResult BodyPlainText([FromBody] string request)
        {
            try
            {
                if (String.IsNullOrEmpty(request) || String.IsNullOrWhiteSpace(request))
                    return new JsonResult("No emails submitted");

                StringFormatRequest stringRequest = new StringFormatRequest(request);
                return new JsonResult(EmailProcessor.CountEmails(stringRequest.CreateList));
            }
            catch (Exception ex)
            {
                return new JsonResult(String.Format("Error Code {0}: {1}", "500", ex.Message));
            }
        }



        [HttpPost]
        [Route("api/BodyTypes/jsonBody")]
        public JsonResult BodyJSON([FromBody] string request)
        {
            try
            {
                if (String.IsNullOrEmpty(request) || String.IsNullOrWhiteSpace(request))
                    return new JsonResult("No emails submitted");

                JSONFormatRequest jsonRequest = new JSONFormatRequest(request);
                return new JsonResult(EmailProcessor.CountEmails(jsonRequest.CreateList));
            }
            catch (Exception ex)
            {
                return new JsonResult(String.Format("Error Code {0}: {1}", "500", ex.Message));
            }
        }

    }
}
