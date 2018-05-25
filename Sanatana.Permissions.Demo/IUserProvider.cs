using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanatana.Permissions.Demo
{
    public interface IUserProvider
    {
        Guid GetCurrentUserId();
    }
}
