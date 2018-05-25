using Sanatana.Permissions.DAL;
using Sanatana.Permissions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanatana.Permissions.DAL.SQL
{
    public class SqlAreaQueries : IAreaQueries<long>
    {


        //methods
        public Task Create(List<Area<long>> areas)
        {
            throw new NotImplementedException();
        }

        public Task<List<Area<long>>> Select()
        {
            throw new NotImplementedException();
        }

        public Task<Area<long>> Select(string areaName)
        {
            throw new NotImplementedException();
        }

        public Task<List<Area<long>>> Select(List<string> areaNames)
        {
            throw new NotImplementedException();
        }

        public Task Update(List<Area<long>> areas)
        {
            throw new NotImplementedException();
        }

        public Task Delete(List<long> areaIds)
        {
            throw new NotImplementedException();
        }

    }
}
