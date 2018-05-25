using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanatana.Permissions.Entities
{
    public class Role<TKey>
        where TKey : struct
    {
        public TKey RoleId {get;set;}
        public string Name { get; set; }
        public DateTime CreatedDateUtc { get; set; }
    }
}
