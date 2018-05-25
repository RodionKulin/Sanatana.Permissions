using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sanatana.Permissions.Extensions;

namespace Sanatana.Permissions.Demo
{
    public class CurrentUserPermissionValidator
    {
        //fields
        private IUserProvider _userProvider;
        private PermissionValidator<Guid, int> _permissionValidator;


        //init
        public CurrentUserPermissionValidator(IUserProvider userProvider, PermissionValidator<Guid, int> permissionValidator)
        {
            _userProvider = userProvider;
            _permissionValidator = permissionValidator;
        }


        //method
        public Task<bool> HasPermissions(Area area, params Permission[] permissions)
        {
            Guid currentUserId = _userProvider.GetCurrentUserId();

            string areaName = area.ToString();

            permissions = permissions ?? new Permission[0];
            long permissionFlags = (long)permissions.Aggregate((a, b) => a.Include(b));

            return _permissionValidator.HasPermission(currentUserId, areaName, permissionFlags);
        }
    }
}
