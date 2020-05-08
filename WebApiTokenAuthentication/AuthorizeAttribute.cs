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
                //create custom response
                actionContext.Response = actionContext.Request.CreateResponse(
                    HttpStatusCode.Unauthorized,
                    new ResponseStatus() { status = "401", message = "Authorization has been denied for this request." }
                );
            }
            else
            {
                actionContext.Response = actionContext.Request.CreateResponse(
                    HttpStatusCode.Forbidden,
                    new ResponseStatus() { status = "403", message = "Forbidden" }
                );
            }
        }
    }
}