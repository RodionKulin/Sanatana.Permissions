using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanatana.Permissions.Entities
{
    public class UserRole<TUserKey, TKey>
        where TUserKey : struct
        where TKey : struct
    {
        public TUserKey UserId { get; set; }
        public TKey RoleId { get; set; }
    }
}
