using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanatana.Permissions.Entities
{
    public class Area<TKey>
        where TKey : struct
    {
        public TKey AreaId { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDateUtc { get; set; }
        public bool IsEnabled { get; set; }
    }
}
