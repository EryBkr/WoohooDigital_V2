using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace MyFramework.Core.CrossCuttingConcerns.Security.Web
{
  public class AuthHelper
    {
        public static void CreateAuthCookie(Guid id,string name,string email,DateTime expiration,string[] roles,bool rememberMe)
        {
            var authTicket = new FormsAuthenticationTicket(1,name,DateTime.Now,expiration,rememberMe,
                CustomUserData(email,roles,id));
            string encTicket = FormsAuthentication.Encrypt(authTicket);
            HttpContext.Current.Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));
        }

        private static string CustomUserData(string email, string[] roles,Guid id)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(email);
            stringBuilder.Append("|");

            for (int i = 0; i < roles.Length; i++)
            {
                stringBuilder.Append(roles[i]);

                if (i<(roles.Length-1))
                {
                    stringBuilder.Append(",");
                }
            }
            stringBuilder.Append("|");
            stringBuilder.Append(id);

            return stringBuilder.ToString();
        }
    }
}
