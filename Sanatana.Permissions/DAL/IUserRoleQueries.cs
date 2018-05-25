using Sanatana.ErrorHandling;
using Sanatana.Permissions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanatana.Permissions.DAL
{
    public interface IUserRoleQueries<TUserKey, TKey>
        where TUserKey : struct
        where TKey : struct
    {
        Task Create(List<UserRole<TUserKey, TKey>> roles);
        Task<List<UserRole<TUserKey, TKey>>> Select();
        Task<List<UserRole<TUserKey, TKey>>> Select(List<TUserKey> userIds);
        Task Update(List<UserRole<TUserKey, TKey>> userRoles);
        Task Delete(List<UserRole<TUserKey, TKey>> userRoles);
        Task Delete(List<TKey> roleIds);
        Task Delete(List<TUserKey> userIds);
    }
}
