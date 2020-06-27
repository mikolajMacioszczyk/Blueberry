using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blueberry.DLL.Models
{
    public enum OrderStatus
    {
        Waiting = 0,
        Realized = 1,
        Cancelled = 2,
        Postponed = 3
    }
}
