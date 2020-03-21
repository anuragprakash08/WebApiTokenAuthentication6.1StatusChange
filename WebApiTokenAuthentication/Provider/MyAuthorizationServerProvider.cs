using Microsoft.Owin.Security.OAuth;
using System;
using System.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApiTokenAuthentication
{
    public class MyAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string clientId = string.Empty;
            string clientSecret = string.Empty;

            if (!context.TryGetBasicCredentials(out clientId, out clientSecret))
            {
                context.TryGetFormCredentials(out clientId, out clientSecret);
            }

            if (context.ClientId == null)
            {
                context.SetError("invalid_client", "Client credentials could not be retrieved through the Authorization header.");
                context.Rejected();

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
                    context.SetError("invalid_client", "Client credentials are invalid.");
                    context.Rejected();
                }
            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message;
                context.SetError("server_error");
                context.Rejected();
            }

            //string resource = context.Parameters.Where(x => x.Key == "resource").Select(y => y.Value).FirstOrDefault()[0];
            //if (resource == ConfigurationManager.AppSettings["resource"].ToString())
            //{
            //    context.Validated(clientId);
            //}
            //else
            //{
            //    context.SetError("invalid_Resource", "Resource credentials are invalid.");
            //    context.Rejected();
            //}


            return;
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            context.Validated(identity);
        }
    }
}