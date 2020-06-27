using System;

namespace Blueberry.DLL.Models
{
    public class Modification
    {
        public Type Type => OldValue.GetType();
        public readonly object OldValue;
        public readonly object NewValue;

        public Modification(object oldValue, object newValue)
        {
            OldValue = oldValue;
            NewValue = newValue;
        }
    }
}