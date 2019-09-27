using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using PostSharp.Aspects;

namespace MyFramework.Core.Aspects.PostSharp
{
    [Serializable]
    public class SecuredOperations:OnMethodBoundaryAspect
    {
        public string Roles { get; set; }

        public override void OnEntry(MethodExecutionArgs args)
        {
            string[] roles = Roles.Split(',');
            bool isAuth = false;
            for (int i = 0; i < roles.Length; i++)
            {
                if (System.Threading.Thread.CurrentPrincipal.IsInRole(roles[i]))
                {
                    isAuth = true;
                }
            }
            if (!isAuth)
            {
                throw new SecurityException("You are not auth");
            }
 
            base.OnEntry(args);
        }
    }
}
