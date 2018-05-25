using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanatana.Permissions.Entities
{
    public class AreaUserPermission<TUserKey, TKey>
        where TUserKey : struct
        where TKey : struct
    {
        public TUserKey UserId { get; set; }
        public TKey AreaId { get; set; }
        public long PermissionFlag { get; set; }
        public bool IsAllowed { get; set; }
        public DateTime CreatedDateUtc { get; set; }
        public TimeSpan? TimeToLive { get; set; }
    }
}
