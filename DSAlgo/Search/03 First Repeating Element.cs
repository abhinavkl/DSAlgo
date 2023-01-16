using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.Search
{
    internal class _03_First_Repeating_Element
    {
        int[] arr { get; set; }
        int n { get { return arr.Length; } }
        public _03_First_Repeating_Element()
        {
            arr = new int[] { 10, 5, 3, 4, 3, 5, 6 };
        }

        public void Solve()
        {
            FindFirstRepeating();
        }

        #region List 
        void FindFirstRepeating()
        {
            int value = 0;
            HashSet<int> store = new HashSet<int>();

            for (int i = 0; i < n; i++)
            {
                if (!store.Contains(arr[i]))
                {
                    store.Add(arr[i]);
                }
                else
                {
                    store.Remove(arr[i]);
                }
            }

            for (int i = 0; i < n; i++)
            {
                if (!store.Contains(arr[i]))
                {
                    value = arr[i];
                    break;
                }
            }

            Console.WriteLine($"first repeating : {value} ");
        }
        #endregion

    }
}
