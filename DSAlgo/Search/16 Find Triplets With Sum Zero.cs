using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.Search
{
    internal class _16_Find_Triplets_With_Sum_Zero
    {
        int[] arr { get; set; }
        int n { get { return arr.Length; } }
        public _16_Find_Triplets_With_Sum_Zero()
        {
            arr = new int[] { 0, -1, 2, -3, 1 };
        }

        public void Solve()
        {
            Sort(arr, n);
            int first = 0;
            int second = 0;
            int third = 0;

            for (first = 0; first < n-2; first++)
            {
                second = first + 1;
                third = n - 1;
                while (second < third)
                {
                    int sum = arr[first] + arr[second] + arr[third];
                    if (sum == 0)
                    {
                        break;
                    }
                    else if (sum > 0)
                        third--;
                    else
                        second++;
                }
            }


        }

        void Sort(int[] arr,int n)
        {
            for(int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(n,i);
            }

            for(int i = n - 1; i >= 0; i--)
            {
                Swap(i, 0);
                Heapify(i, 0);
            }
        }

        void Heapify(int lastIndex,int index)
        {
            int left = 2 * index + 1;
            int right=2* index + 2;

            int actualIndex = index;

            if (left < lastIndex && arr[left] > arr[actualIndex])
                actualIndex = left;
            if(right<lastIndex && arr[right] > arr[actualIndex])
                actualIndex = right;

            if (actualIndex != index)
            {
                Swap(actualIndex,index);
                Heapify(lastIndex, actualIndex);
            }
        }

        void Swap(int a,int b)
        {
            if (arr[a] != arr[b])
            {
                arr[a] ^= arr[b];
                arr[b] ^= arr[a];
                arr[a] ^= arr[b];
            }
        }
    }
}
