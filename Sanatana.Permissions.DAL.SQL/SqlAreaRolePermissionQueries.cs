using Sanatana.Permissions.DAL;
using Sanatana.Permissions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanatana.Permissions.DAL.SQL
{
    public class SqlAreaRolePermissionQueries : IAreaRolePermissionQueries<long>
    {


        //methods
        public Task Create(List<AreaRolePermission<long>> areaRolePermissions)
        {
            throw new NotImplementedException();
        }

        public Task<long> Count(List<long> roleIds = null, List<long> areaIds = null)
        {
            throw new NotImplementedException();
        }

        public Task<List<AreaRolePermission<long>>> Select(List<long> roleIds = null, List<long> areaIds = null)
        {
            throw new NotImplementedException();
        }

        public Task Update(List<AreaRolePermission<long>> areaRolePermissions)
        {
            throw new NotImplementedException();
        }

        public Task Delete(List<AreaRolePermission<long>> areaRolePermissions)
        {
            throw new NotImplementedException();
        }

    }
}
