using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.Search
{
    internal class _06_Find_Pair_With_Given_Difference
    {
        int[] arr { get; set; }
        int n { get { return arr.Length; } }
        int diff;
        public _06_Find_Pair_With_Given_Difference()
        {
            arr = new int[] { 5, 20, 3, 2, 50, 80 };
            diff = 45;
        }

        public void Solve()
        {
            Sort();

            int first = 0;
            int second = 0;

            for (int i = 0; i < n - 1; i++)
            {
                int search = diff + arr[i];
                if (search > 0)
                {
                    int pos = SearchElement(i + 1, n - 1, search);
                    if (pos != -1)
                    {
                        first = i;
                        second = pos;
                        break;
                    }
                }
            }

            if (first != 0 && second != 0)
            {
                Console.WriteLine($"first : {first} \nsecond : {second} ");
            }

        }

        int SearchElement(int start, int end, int search)
        {
            if (start < end)
            {
                int mid = (end - start) / 2 + start;

                if (arr[mid] == search)
                    return mid;
                else if (arr[mid] > search)
                    return SearchElement(start, mid, search);
                else
                    return SearchElement(mid + 1, end, search);
            }
            return -1;
        }

        void Sort()
        {
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(n, i);
            }

            for (int i = n - 1; i >= 0; i--)
            {
                Swap(i, 0);
                Heapify(i, 0);
            }

        }

        void Heapify(int lastElementIndex, int index)
        {
            int left = 2 * index + 1;
            int right = 2 * index + 2;

            int actualMaxIndex = index;

            if (left < lastElementIndex && arr[left] > arr[actualMaxIndex])
                actualMaxIndex = left;
            if (right < lastElementIndex && arr[right] > arr[actualMaxIndex])
                actualMaxIndex = right;

            if (actualMaxIndex != index)
            {
                Swap(actualMaxIndex, index);
                Heapify(actualMaxIndex, index);
            }
        }

        void Swap(int swapFrom, int swapTo)
        {
            if (arr[swapFrom] != arr[swapTo])
            {
                arr[swapFrom] ^= arr[swapTo];
                arr[swapTo] ^= arr[swapFrom];
                arr[swapFrom] ^= arr[swapTo];
            }
        }


    }
}
