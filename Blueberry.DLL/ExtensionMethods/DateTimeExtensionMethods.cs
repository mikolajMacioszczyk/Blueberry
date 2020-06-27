using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blueberry.DLL.ExtensionMethods
{
    public static class DateTimeExtensionMethods
    {
        public static int CompareTo(this DateTime dateTime, DateTime other)
        {
            return DateTime.Compare(dateTime, other);
        }
    }
}
