using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.Greedy
{
    internal class _02_Minimum_Inc_Dec_To_Make_Array_Non_Increasing
    {
        int[] arr { get; set; }
        int n { get { return arr.Length; } }
        public _02_Minimum_Inc_Dec_To_Make_Array_Non_Increasing()
        {
            arr = new int[] { 3, 1, 5, 1 };
        }

        public void Solve()
        {
            SortedSet<int> list = new SortedSet<int>();
            int sum = 0;

            for(int i = 0; i < n; i++)
            {
                if(list.Count>0 && list.Max < arr[i])
                {
                    int diff = arr[i] - list.Max;
                    sum+= diff;
                    list.Remove(list.Max);
                    list.Add(arr[i]);
                }
                else  
                    list.Add(arr[i]);
            }
        }

    }
}
