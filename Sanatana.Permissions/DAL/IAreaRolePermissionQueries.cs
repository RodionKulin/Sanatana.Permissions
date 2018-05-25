using Sanatana.ErrorHandling;
using Sanatana.Permissions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanatana.Permissions.DAL
{
    public interface IAreaRolePermissionQueries<TKey>
        where TKey : struct
    {
        Task Create(List<AreaRolePermission<TKey>> areaRolePermissions);
        Task<List<AreaRolePermission<TKey>>> Select(List<TKey> roleIds = null, List<TKey> areaIds = null);
        Task<long> Count(List<TKey> roleIds = null, List<TKey> areaIds = null);
        Task Update(List<AreaRolePermission<TKey>> areaRolePermissions);
        Task Delete(List<AreaRolePermission<TKey>> areaRolePermissions);
    }
}
