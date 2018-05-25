using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sanatana.Permissions.Entities;

namespace Sanatana.Permissions.DAL.SQL
{
    public class SqlRoleQueries : IRoleQueries<long>
    {


        //methods
        public Task Create(List<Role<long>> roles)
        {
            throw new NotImplementedException();
        }

        public Task<List<Role<long>>> Select()
        {
            throw new NotImplementedException();
        }

        public Task Update(List<Role<long>> roles)
        {
            throw new NotImplementedException();
        }

        public Task Delete(List<long> roleIds)
        {
            throw new NotImplementedException();
        }

    }
}
