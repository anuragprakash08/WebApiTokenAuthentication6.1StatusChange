using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using WebApiTokenAuthentication.Models;

namespace WebApiTokenAuthentication
{
    //Here will handle unauhorized request
    public class AuthorizeAttribute : System.Web.Http.AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                EventLogger.Log("APIVoucherUpdate.PostAPIVoucherUpdateControl", "PostAPIVoucherUpdateControl", EventLogger.Event.START, "Authorization has been denied for this request. :");
                //create custom response
                actionContext.Response = actionContext.Request.CreateResponse(
                    HttpStatusCode.Unauthorized,
                    new AuthResponseStatus() { status = "401", message = "Authorization has been denied for this request." }
                );
            }
            else
            {
                EventLogger.Log("APIVoucherUpdate.PostAPIVoucherUpdateControl", "PostAPIVoucherUpdateControl", EventLogger.Event.START, "Forbidden :");
                actionContext.Response = actionContext.Request.CreateResponse(
                    HttpStatusCode.Forbidden,
                    new AuthResponseStatus() { status = "403", message = "Forbidden" }
                );
            }
        }
    }
}