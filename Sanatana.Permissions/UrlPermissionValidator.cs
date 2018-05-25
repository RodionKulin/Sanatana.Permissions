using FluentSecurity;
using Sanatana.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanatana.Permissions
{
    public class UrlPermissionValidator<TUserKey, TKey>
        where TUserKey : struct
        where TKey : struct
    {
        //fields
        protected PermissionValidator<TUserKey, TKey> _permissionValidator;


        //init
        public UrlPermissionValidator(PermissionValidator<TUserKey, TKey> permissionValidator)
        {
            _permissionValidator = permissionValidator;
        }


        //methods
        public bool CheckActionPermission(string actionName, string controllerFullName)
        {
            ISecurityContext context = SecurityContext.Current;
            ISecurityRuntime runtime = context.Runtime;

            IPolicyContainer policyContainer = runtime.PolicyContainers
                .GetContainerFor(controllerFullName, actionName);
            IEnumerable<PolicyResult> policyResults = policyContainer.EnforcePolicies(context);
            bool valid = policyResults.All(p => !p.ViolationOccured);

            return valid;
        }

        public bool CheckActionPermission(string actionName, Type controllerType)
        {
            string controllerFullName = controllerType.FullName;
            return CheckActionPermission(actionName, controllerFullName);
        }

        public void CheckUrlPermission(List<SecuredUrl> urls)
        {
            foreach (SecuredUrl url in urls)
            {
                url.HasPermission = CheckActionPermission(url.ActionName, url.ControllerFullName);
            }
        }

        public void CheckUrlPermission(SecuredUrl url)
        {
            url.HasPermission = CheckActionPermission(url.ActionName, url.ControllerFullName);
        }



    }
}
