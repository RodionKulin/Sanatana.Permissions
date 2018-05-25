using Sanatana.ErrorHandling;
using Sanatana.Permissions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanatana.Permissions.DAL
{
    public interface IAreaQueries<TKey>
        where TKey : struct
    {
        Task Create(List<Area<TKey>> areas);
        Task<List<Area<TKey>>> Select();
        Task<Area<TKey>> Select(string areaName);
        Task<List<Area<TKey>>> Select(List<string> areaNames);
        Task Update(List<Area<TKey>> areas);
        Task Delete(List<TKey> areaIds);
    }
}
