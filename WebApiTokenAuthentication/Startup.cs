using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Configuration;
using System.Web.Http;

[assembly: OwinStartup(typeof(WebApiTokenAuthentication.Startup))]

namespace WebApiTokenAuthentication
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            var myprovider = new MyAuthorizationServerProvider();

            OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,//should be disabled in production
                TokenEndpointPath = new PathString("/oauth/token"),//this is the path where user will get the token
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(Convert.ToDouble(ConfigurationManager.AppSettings["expire_time"])),
                Provider = myprovider
            };

            app.UseOAuthAuthorizationServer(options);
            // Enable the application to use bearer tokens to authenticate users
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
        }
    }
}