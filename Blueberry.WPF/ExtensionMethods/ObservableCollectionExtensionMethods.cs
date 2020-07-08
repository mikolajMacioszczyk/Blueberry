using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blueberry.WPF.ExtensionMethods
{
    public static class ObservableCollectionExtensionMethods
    {
        public static void Sort<T>(this ObservableCollection<T> collection, Func<T, T, int> comparer)
        {
            if (collection == null)
            {
                return;
            }
            for (int i = 0; i < collection.Count-1; i++)
            {
                bool isSorted = true;
                for (int j = 0; j < collection.Count-1-i; j++)
                {
                    if (comparer.Invoke(collection[j], collection[j + 1]) > 0)
                    {
                        isSorted = false;
                        Swap(collection, j, j + 1);
                    }
                }
                if (isSorted)
                {
                    return;
                }
            }
        }

        private static void Swap<T>(Collection<T> collection, int index1, int index2)
        {
            T temp = collection[index1];
            collection[index1] = collection[index2];
            collection[index2] = temp;
        }

    }
}
