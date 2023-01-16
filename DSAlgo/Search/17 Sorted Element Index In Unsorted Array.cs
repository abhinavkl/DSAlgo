using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.Search
{
    internal class _17_Sorted_Element_Index_In_Unsorted_Array
    {
        int[] arr { get; set; }
        int n { get { return arr.Length; } }
        public _17_Sorted_Element_Index_In_Unsorted_Array()
        {
            //arr = new int[] { 0,1,3, 4,5,2, 6, 8, 10, 7, 9 };
            arr = new int[] { 4, 2, 5, 7 };
        }

        public void Solve()
        {
            int sortedElementIndex = SortedElementIndex(arr);
        }


        /// <summary>
        /// if it is continuously increases. only when bit is true set max
        /// if bit is false or continuously decreasing increment i.
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        int SortedElementIndex(int[] a)
        {
            // Base case
            if (n == 1 || n == 2)
            {
                return -1;
            }

            // 1.sortedElement is the possible candidate for
            // the solution of the problem.
            // 2.sortedElementIndex is the index of the possible
            // candidate.
            // 3.leftMax is the value which is maximum on the
            // left side of the array.
            // 4.bit tell whether the loop is
            // terminated from the if condition or from
            // the else condition when loop do not
            // satisfied the condition.
            // 5.indexFound is the variable which tell whether the
            // sortedElement is updated or not
            int leftMax = arr[0],
                    bit = -1, indexFound = 0;
            int sortedElementIndex = -1;

            // The extreme two of the array can
            // not be the solution. Therefore
            // iterate the loop from i = 1 to < n-1
            for (int i = 1; i < n-1;)
            {

                // Here we find the possible candidate
                // where Element with left side smaller
                // and right side greater. When the if
                // condition fail we indexFound and update in
                // else condition.
                if (arr[i] < leftMax && i < n-1)
                {
                    i++;
                    bit = 0;
                }

                // Here we update the possible sortedElement
                // if the sortedElement is greater than the
                // leftMax (maximum sortedElement so far). In
                // while loop we sur-pass the value which
                // is greater than the sortedElement
                else
                {
                    if (arr[i] >= leftMax)
                    {
                        sortedElementIndex = i;
                        indexFound = 1;
                        leftMax = arr[i];
                    }
                    if (indexFound == 1)
                    {
                        i++;
                    }
                    bit = 1;

                    while (arr[i] >= arr[sortedElementIndex] && i < n-1)
                    {
                        if (arr[i] > leftMax)
                        {
                            leftMax = arr[i];
                        }
                        i++; 
                    }
                    indexFound = 0;
                }
            }

            // Checking for the last value and whether
            // the loop is terminated from else or
            // if block.
            if (arr[sortedElementIndex] <= arr[n - 1] && bit == 1)
            {
                return sortedElementIndex;
            }
            else
            {
                return -1;
            }
        }
    }
}
