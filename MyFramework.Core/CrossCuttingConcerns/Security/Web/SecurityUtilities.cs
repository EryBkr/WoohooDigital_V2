using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace MyFramework.Core.CrossCuttingConcerns.Security.Web
{
    public class SecurityUtilities
    {
        public Identity FormsAuthTicketToIdentity(FormsAuthenticationTicket ticket)
        {
            var identity = new Identity()
            {
                Name = ticket.Name,
                Id = SetId(ticket),
                Roles = SetRoles(ticket),
                Email = SetEmail(ticket),
                IsAuthenticated = true,
                AuthenticationType="Forms"
            };
            return identity;
        }

        private string SetEmail(FormsAuthenticationTicket ticket)
        {
            var data = ticket.UserData.Split('|')[0];
            return data;
        }

        private string[] SetRoles(FormsAuthenticationTicket ticket)
        {
            var data = ticket.UserData.Split('|')[1];
            var roles = data.Split(',');
            return roles;
        }

        private Guid SetId(FormsAuthenticationTicket ticket)
        {
            var data = ticket.UserData.Split('|')[2];
            return Guid.Parse(data);
        }
    }
}
