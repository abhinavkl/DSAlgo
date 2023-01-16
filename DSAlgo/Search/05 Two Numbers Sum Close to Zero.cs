using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.Search
{
    internal class _05_Two_Numbers_Sum_Close_to_Zero
    {
        int[] arr { get; set; }
        int n { get { return arr.Length; } }
        public _05_Two_Numbers_Sum_Close_to_Zero()
        {
            arr = new int[] { 1, 60, -10, 70, -80, 85 };
        }

        /// <summary>
        /// 
        /// 1. Sort the array. result: { -80,-10, 1, 60, 70, 85 }
        /// 2. For each -ve number get the number with best abs difference.
        /// 
        /// </summary>
        public void Solve()
        {
            Sort();

            int firstPosIndex = FirstPosIndex(0,n-1);

            int first = 0;
            int second=0;

            int abs = int.MaxValue;

            for (int i = 0; i < n; i++)
            {
                if (arr[i] < 0)
                {
                    int bestAbsIndex = BestAbsIndex(arr[i],firstPosIndex,n-1);
                    int cur_abs =Math.Abs(arr[i] + arr[bestAbsIndex]);
                    if (abs > cur_abs)
                    {
                        abs = cur_abs;
                        first = i;
                        second = bestAbsIndex;
                    }
                }
            }

            if (abs == int.MaxValue)
            {
                first = arr[0];
                second = arr[1];
                abs = first + second;
            }

        }

        /// <summary>
        /// 
        /// -80     1 10 40 80 90 120 160
        ///         -79 -70 -40 0 10 40 80
        ///         
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        int BestAbsIndex(int key,int start,int end)
        {
            if (start < end)
            {
                int mid=(end-start)/2+start;

                if (arr[mid] + key == 0)
                    return mid;
                else if (Math.Abs(arr[mid] + key) < Math.Abs(arr[mid+1] + key))
                    return BestAbsIndex(key, start, mid);
                else
                    return BestAbsIndex(key, mid+1, end);
            }
            return start;
        }

        int FirstPosIndex(int start,int end)
        {
            if (start < end)
            {
                int mid=(end-start)/2+start;
                if (arr[mid] == 0)
                    return mid;
                else if (arr[mid] > 0)
                    return FirstPosIndex(start, mid);
                else
                    return FirstPosIndex(mid + 1, end);
            }
            return start;
        }
        
        /// <summary>
        /// 1. Set first minimum element.
        /// </summary>
        void Sort()
        {
            SetFirstMaximumElement();

            for(int i = n - 1; i >= 0; i--)
            {
                Swap(i,0);
                Heapify(i,0);
            }
        }

        void SetFirstMaximumElement()
        {
            for(int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(n,i);
            }
        }

        void Heapify(int lastElementIndex,int index)
        {
            int left = 2 * index + 1;
            int right = 2 * index + 2;

            int actualMaxIndex = index;

            if(left < lastElementIndex && arr[left] > arr[actualMaxIndex])
                actualMaxIndex = left;

            if (right < lastElementIndex && arr[right] > arr[actualMaxIndex])
                actualMaxIndex = right;

            if (actualMaxIndex != index)
            {
                Swap(actualMaxIndex,index);
                Heapify(lastElementIndex,actualMaxIndex);
            }
        }

        void Swap(int swapFrom,int swapTo)
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
