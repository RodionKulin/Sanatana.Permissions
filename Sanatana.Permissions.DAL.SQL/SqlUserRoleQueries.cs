using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sanatana.Permissions.Entities;

namespace Sanatana.Permissions.DAL.SQL
{
    public class SqlUserRoleQueries : IUserRoleQueries<long, long>
    {

        //methods
        public Task Create(List<UserRole<long, long>> roles)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserRole<long, long>>> Select()
        {
            throw new NotImplementedException();
        }

        public Task<List<UserRole<long, long>>> Select(List<long> userIds)
        {
            throw new NotImplementedException();
        }

        public Task Update(List<UserRole<long, long>> userRoles)
        {
            throw new NotImplementedException();
        }

        public Task Delete(List<UserRole<long, long>> userRoles)
        {
            throw new NotImplementedException();
        }

        public Task Delete(List<long> roleIds)
        {
            throw new NotImplementedException();
        }
    }
}
