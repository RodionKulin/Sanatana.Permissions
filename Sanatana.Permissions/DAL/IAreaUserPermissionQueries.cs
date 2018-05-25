using Sanatana.Permissions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanatana.Permissions.DAL
{
    public interface IAreaUserPermissionQueries<TUserKey, TKey>
        where TUserKey : struct
        where TKey : struct
    {
        Task Create(List<AreaUserPermission<TUserKey, TKey>> areaUserPermissions);
        Task<List<AreaUserPermission<TUserKey, TKey>>> Select(List<TUserKey> userIds = null, List<TKey> areaIds = null);
        Task<long> Count(List<TUserKey> userIds = null, List<TKey> areaIds = null);
        Task Update(List<AreaUserPermission<TUserKey, TKey>> areaUserPermissions);
        Task Delete(List<AreaUserPermission<TUserKey, TKey>> areaUserPermissions);
    }
}
