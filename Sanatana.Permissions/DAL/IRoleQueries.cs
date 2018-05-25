using Sanatana.ErrorHandling;
using Sanatana.Permissions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanatana.Permissions.DAL
{
    public interface IRoleQueries<TKey>
        where TKey : struct
    {
        Task Create(List<Role<TKey>> roles);
        Task<List<Role<TKey>>> Select();
        Task Update(List<Role<TKey>> roles);
        Task Delete(List<TKey> roleIds);
    }
}
