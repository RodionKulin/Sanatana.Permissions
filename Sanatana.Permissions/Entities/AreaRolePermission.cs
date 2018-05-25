using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanatana.Permissions.Entities
{
    public class AreaRolePermission<TKey>
        where TKey : struct
    {
        public TKey RoleId { get; set; }
        public TKey AreaId { get; set; }
        public long PermissionFlags { get; set; }
        public DateTime CreatedDateUtc { get; set; }
    }
}
