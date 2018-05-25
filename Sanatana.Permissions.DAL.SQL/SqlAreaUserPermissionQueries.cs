using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sanatana.Permissions.Entities;

namespace Sanatana.Permissions.DAL.SQL
{
    public class SqlAreaUserPermissionQueries : IAreaUserPermissionQueries<long, long>
    {

        //methods
        public Task<long> Count(List<long> userIds = null, List<long> areaIds = null)
        {
            throw new NotImplementedException();
        }

        public Task Create(List<AreaUserPermission<long, long>> areaUserPermissions)
        {
            throw new NotImplementedException();
        }

        public Task Delete(List<AreaUserPermission<long, long>> areaUserPermissions)
        {
            throw new NotImplementedException();
        }

        public Task<List<AreaUserPermission<long, long>>> Select(List<long> userIds = null, List<long> areaIds = null)
        {
            throw new NotImplementedException();
        }

        public Task Update(List<AreaUserPermission<long, long>> areaUserPermissions)
        {
            throw new NotImplementedException();
        }
    }
}
