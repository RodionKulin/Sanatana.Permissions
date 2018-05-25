using Sanatana.ErrorHandling;
using Sanatana.Permissions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sanatana.Permissions.Extensions;
using Sanatana.Permissions.DAL;

namespace Sanatana.Permissions
{
    public class PermissionValidator<TUserKey, TKey>
        where TUserKey : struct
        where TKey : struct
    {
        //fields
        protected IAreaQueries<TKey> _areaQueries;
        protected IUserRoleQueries<TUserKey, TKey> _userRoleQueries;
        protected IAreaRolePermissionQueries<TKey> _areaRolePermissionQueries;
        protected IAreaUserPermissionQueries<TUserKey, TKey> _areaUserPermissionQueries;


        //init
        public PermissionValidator(IAreaQueries<TKey> areaQueries, IUserRoleQueries<TUserKey, TKey> userRoleQueries
            , IAreaRolePermissionQueries<TKey> areaRolePermissionQueries, IAreaUserPermissionQueries<TUserKey, TKey> areaUserPermissionQueries)
        {
            _areaQueries = areaQueries;
            _userRoleQueries = userRoleQueries;
            _areaRolePermissionQueries = areaRolePermissionQueries;
            _areaUserPermissionQueries = areaUserPermissionQueries;
        }


        //methods
        public async Task<bool> HasPermission(TUserKey userId, string securedAreaName, long requiredPermissionFlags)
        {
            //check area enabled
            Area<TKey> area = await _areaQueries.Select(securedAreaName).ConfigureAwait(false);
            if (area == null || area.IsEnabled == false)
            {
                return false;
            }

            //check all required permissions are present in user permissions list
            long userPermissionFlags = await GetResultPermissions(userId, area.AreaId)
                .ConfigureAwait(false);
            bool allPermissionsMet = userPermissionFlags.Has(requiredPermissionFlags);
            return allPermissionsMet;
        }

        protected async Task<long> GetResultPermissions(TUserKey userId, TKey areaId)
        {
            Task<long> rolePermissionsTask = GetRolePermissions(userId, areaId);
            Task<List<AreaUserPermission<TUserKey, TKey>>> userPermissionsTask = GetUserPermissions(userId, areaId);

            //role permissions
            long rolePermissions = await rolePermissionsTask.ConfigureAwait(false);

            //user permissions
            List<AreaUserPermission<TUserKey, TKey>> userPermissions = 
                await userPermissionsTask.ConfigureAwait(false);
            long allowPermissions = userPermissions
                .Where(x => x.IsAllowed == true)
                .Select(x => x.PermissionFlag)
                .Aggregate((a, b) => a.Include(b));
            long disallowPermissions = userPermissions
                .Where(x => x.IsAllowed == false)
                .Select(x => x.PermissionFlag)
                .Aggregate((a, b) => a.Include(b));

            //summary
            long permissionsFlags = rolePermissions.Include(allowPermissions);
            permissionsFlags = permissionsFlags.Remove(disallowPermissions);
            return permissionsFlags;
        }

        protected async Task<long> GetRolePermissions(TUserKey userId, TKey areaId)
        {
            List<UserRole<TUserKey, TKey>> userRoles = await _userRoleQueries.Select(new List<TUserKey> { userId })
               .ConfigureAwait(false);
            List<TKey> userRoleIds = userRoles.Select(x => x.RoleId).ToList();

            List<AreaRolePermission<TKey>> rolePermissions =
                await _areaRolePermissionQueries.Select(roleIds: userRoleIds, areaIds: new List<TKey> { areaId })
                .ConfigureAwait(false);

            long permissionsFlags = rolePermissions.Select(x => x.PermissionFlags)
                .Aggregate((a, b) => a.Include(b));
            return permissionsFlags;
        }

        protected async Task<List<AreaUserPermission<TUserKey, TKey>>> GetUserPermissions(TUserKey userId, TKey areaId)
        {
            List<AreaUserPermission<TUserKey, TKey>> userPermissions = await _areaUserPermissionQueries.Select(
                    userIds: new List<TUserKey> { userId }
                    , areaIds: new List<TKey> { areaId })
                .ConfigureAwait(false);

            List<AreaUserPermission<TUserKey, TKey>> expiredPermissions = userPermissions.Where(
                x => x.TimeToLive != null
                && x.CreatedDateUtc.Add(x.TimeToLive.Value) < DateTime.UtcNow)
                .ToList();
            await _areaUserPermissionQueries.Delete(expiredPermissions)
                .ConfigureAwait(false);

            userPermissions = userPermissions.Except(expiredPermissions).ToList();
            return userPermissions;
        }


    }
}
