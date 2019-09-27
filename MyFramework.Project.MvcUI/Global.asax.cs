using FluentValidation.Mvc;
using MyFramework.Core.CrossCuttingConcerns.Security.Web;
using MyFramework.Core.CrossCuttingConcerns.Validation.FluentValidation;
using MyFramework.Core.Utilities.Mvc.Infastructure;
using MyFramework.Project.Business.DependencyResolvers.Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace MyFramework.Project.MvcUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            log4net.Config.XmlConfigurator.Configure();
            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(new BusinessModule()));
            FluentValidationModelValidatorProvider.Configure(provider => provider.ValidatorFactory = new NinjectValidationFactory(new ValidationModule()));
        }

        public override void Init()
        {
            PostAuthenticateRequest += MvcApplication_PostAuthenticateRequest;
            base.Init();
        }

        private void MvcApplication_PostAuthenticateRequest(object sender, EventArgs e)
        {
            try
            {
                var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];

                if (authCookie == null)
                {
                    return;
                }

                var encTicket = authCookie.Value;

                if (String.IsNullOrEmpty(encTicket))
                {
                    return;
                }

                var ticket = FormsAuthentication.Decrypt(encTicket);

                var secureUtilities = new SecurityUtilities();
                var identity = secureUtilities.FormsAuthTicketToIdentity(ticket);

                var principal = new GenericPrincipal(identity, identity.Roles);
                HttpContext.Current.User = principal;
                Thread.CurrentPrincipal = principal;
            }
            catch (Exception)
            {

                
            }

        }
    }
}
