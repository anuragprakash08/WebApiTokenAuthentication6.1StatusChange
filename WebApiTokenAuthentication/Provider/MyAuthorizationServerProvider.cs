using Microsoft.Owin.Security.OAuth;
using System;
using System.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApiTokenAuthentication.Models;

namespace WebApiTokenAuthentication
{
    public class MyAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            EventLogger.Log("APIVoucherUpdate.PostAPIVoucherUpdateControl", "ValidateClientAuthentication", EventLogger.Event.START, "ValidateClientAuthentication method called :");
            string clientId = string.Empty;
            string clientSecret = string.Empty;

            if (!context.TryGetBasicCredentials(out clientId, out clientSecret))
            {
                context.TryGetFormCredentials(out clientId, out clientSecret);
            }

            if (context.ClientId == null)
            {
                context.Rejected();
                context.SetError("invalid_client", "Client credentials could not be retrieved through the Authorization header.");

                return;
            }

            try
            {
                if (clientId == ConfigurationManager.AppSettings["client_id"].ToString() && clientSecret == ConfigurationManager.AppSettings["client_secret"].ToString())
                {
                    context.Validated(clientId);
                }
                else
                {
                    context.Rejected();
                    context.SetError("invalid_client", "Client credentials are invalid.");
                }
            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message;
                context.Rejected();
                context.SetError("server_error");
            }

            string resource = context.Parameters.Where(x => x.Key == "resource").Select(y => y.Value).FirstOrDefault()[0];
            if (resource == ConfigurationManager.AppSettings["resource"].ToString() && context.IsValidated)
            {
                context.Validated(clientId);
            }
            else
            {
                if(context.IsValidated)
                {
                    context.Rejected();
                    context.SetError("invalid_Resource", "Resource credentials are invalid.");
                }

            }
            EventLogger.Log("APIVoucherUpdate.PostAPIVoucherUpdateControl", "ValidateClientAuthentication", EventLogger.Event.END, "ValidateClientAuthentication method called :");
            return;
        }

        public override async Task GrantClientCredentials(OAuthGrantClientCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            context.Validated(identity);
        }
    }
}