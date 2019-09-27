using MyFramework.Project.Business.Abstract;
using MyFramework.Project.Business.DependencyResolvers.Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace MyFramework.Project.WebAPI.MessageHandlers
{
    public class AuthenticationHandler:DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                var token = request.Headers.GetValues("Authorization").FirstOrDefault();
                if (token != null)
                {
                    byte[] data = Convert.FromBase64String(token);
                    string decodedString = Encoding.UTF8.GetString(data);
                    string[] tokenValues = decodedString.Split(':');

                    IUserManager _userService = InstanceFactory.GetInstance<IUserManager>();

                    var user = _userService.GetUserNameAndPassword(tokenValues[0], tokenValues[1]);

                    if (user!=null)
                    {
                        var principal = new GenericPrincipal(new GenericIdentity(user.Name),user.myRole);
                        Thread.CurrentPrincipal = principal;
                        HttpContext.Current.User = principal; 
                    }
                }
            }
            catch
            {


            }
            return base.SendAsync(request, cancellationToken);
        }
    }
}