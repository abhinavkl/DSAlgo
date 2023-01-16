using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.Search
{
    internal class _15_Find_Pivot_Element
    {
        int[] arr { get; set; }
        int n { get { return arr.Length; } }
        public _15_Find_Pivot_Element()
        {
            //arr =new int[] { 8, 10, 20, 80, 100, 200, 400, 500, 3, 2, 1 };
            arr = new int[] { 0, 1, 1, 2, 2, 2, 2, 2, 3, 4, 4, 5, 3, 3, 2, 2, 1, 1 };
        }

        public void Solve()
        {
            int pivot=FindPivot(arr,0,arr.Length-1);
        }

        int FindPivot(int[] arr,int start,int end)
        {
            while (start < end)
            {
                int mid = (end - start) / 2 + start;
                if (arr[mid] <= arr[mid + 1])
                    return FindPivot(arr, mid+1, end);
                else return FindPivot(arr, start, mid);
            }

            return start;
        }

    }
}
