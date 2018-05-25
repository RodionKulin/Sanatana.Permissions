using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanatana.Permissions.Demo
{
    public enum Permission : long
    {
        Create = 0x1,
        Read = 0x2,
        Update = 0x4,
        Delete = 0x8,
        Print = 0x10,
        Notify = 0x20,
        Moderate = 0x40
    }
}
