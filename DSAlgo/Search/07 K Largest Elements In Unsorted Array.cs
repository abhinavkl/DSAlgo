using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.Search
{
    internal class _07_K_Largest_Elements_In_Unsorted_Array
    {
        int[] arr { get; set; }
        int n { get { return arr.Length; } }
        int k;
        int[] output { get; set; }
        public _07_K_Largest_Elements_In_Unsorted_Array()
        {
            arr = new int[] { 10, 3, 7, 2, 8, 4, 6, 5, 1, 9 };
            k = 4;
            output = new int[k];
        }

        public void Solve()
        {
            for (int i = n/2-1;i>=0 ; i--)
            {
                Heapify(arr,n,i);
            }

            for(int i = n - 1, j = 0; j < k; j++, i--)
            {
                Swap(arr,i,0);
                Heapify(arr,i,0);
                output[j] = arr[i];
            }
        }
      
        void Heapify(int[] array,int lastElementIndex, int index)
        {
            int left = 2 * index + 1;
            int right = 2 * index + 2;

            int actualMaxIndex = index;

            if (left < lastElementIndex && array[left] > array[actualMaxIndex])
                actualMaxIndex = left;
            if (right < lastElementIndex && array[right] > array[actualMaxIndex])
                actualMaxIndex = right;

            if (actualMaxIndex != index)
            {
                Swap(array,actualMaxIndex, index);
                Heapify(array,lastElementIndex, actualMaxIndex);
            }
        }

        void Swap(int[] array, int swapFrom, int swapTo)
        {
            if (array[swapFrom] != array[swapTo])
            {
                array[swapFrom] ^= array[swapTo];
                array[swapTo] ^= array[swapFrom];
                array[swapFrom] ^= array[swapTo];
            }
        }

    }
}
