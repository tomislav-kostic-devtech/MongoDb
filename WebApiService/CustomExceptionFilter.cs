using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;

namespace WebApiService
{
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            string message;
            HttpStatusCode statuscode;
            if (actionExecutedContext.Exception is NotFoundEntityEx)
            {
                message = ((NotFoundEntityEx)actionExecutedContext.Exception).Message;
                statuscode = HttpStatusCode.NotFound;
            }
            else
            {
                message = actionExecutedContext.Exception.Message;
                statuscode = HttpStatusCode.BadRequest;
            }

            actionExecutedContext.Response = new HttpResponseMessage()
            {
                Content = new StringContent(message, System.Text.Encoding.UTF8, "text/plain"),
                StatusCode = statuscode
            };
            
            log.Error("ACTION:["+actionExecutedContext.ActionContext.ActionDescriptor.ActionName+"] - MESSAGE: "+message);

            throw new HttpResponseException(actionExecutedContext.Response);
           //base.OnException(actionExecutedContext);

        }

    }
}