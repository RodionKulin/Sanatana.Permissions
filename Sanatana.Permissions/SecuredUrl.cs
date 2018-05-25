using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanatana.Permissions
{
    public class SecuredUrl
    {
        //fields
        protected bool? _hasPermission;


        //properties
        public string Url { get; set; }
        public string ControllerFullName { get; set; }
        public string ActionName { get; set; }
        public bool? HasPermission
        {
            get
            {
                if (_hasPermission == null)
                {
                    throw new Exception("Permission was not checked yet.");
                }
                return _hasPermission;
            }
            set
            {
                _hasPermission = value;
            }
        }


        //dependent properties
        public string HasPermissionJS
        {
            get
            {
                return HasPermission.Value.ToString().ToLower();
            }
        }


        //init
        public SecuredUrl()
        {
        }
        public SecuredUrl(string actionName, string controllerFullName)
        {
            ActionName = actionName;
            ControllerFullName = controllerFullName;
        }
    }
}
