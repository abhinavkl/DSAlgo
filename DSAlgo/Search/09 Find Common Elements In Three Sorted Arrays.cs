using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.Search
{
    internal class _09_Find_Common_Elements_In_Three_Sorted_Arrays
    {
        int[] arr1 { get; set; }
        int[] arr2 { get; set; }
        int[] arr3 { get; set; }
        List<int> output { get; set; }
        public _09_Find_Common_Elements_In_Three_Sorted_Arrays()
        {
            arr1 = new int[] { 1, 5, 10, 20, 40, 80 };
            arr2 = new int[] { 6, 7, 20, 80, 100 };
            arr3 = new int[] { 3, 4, 15, 20, 30, 70, 80, 120 };
            output = new List<int>();
        }

        public void Solve()
        {
            int a1Length = arr1.Length;
            int a2Length= arr2.Length;
            int a3Length=arr3.Length;
            if(a1Length<=a2Length && a1Length<=a3Length)
            {
                FindCommonElements(arr1,arr2,arr3,a1Length,a2Length,a3Length);
            }
            else if(a2Length<=a1Length && a2Length<=a3Length)
            {
                FindCommonElements(arr2, arr1, arr3, a2Length, a1Length, a3Length);
            }
            else
            {
                FindCommonElements(arr3, arr2, arr1, a3Length, a2Length, a1Length);
            }
        }

        #region Solution

        void FindCommonElements(int[] a1, int[] a2, int[] a3,int a1Length,int a2Length,int a3Length)
        {
            int a1Index = 0, a2Index = 0, a3Index = 0;

            while (true)
            {
                while (a2[a2Index] < a1[a1Index])
                {
                    if (a2Index+1 < a2Length)
                        a2Index++;
                    else break;
                }

                if (a2[a2Index] == a1[a1Index])
                {
                    while (a3[a3Index] < a1[a1Index])
                    {
                        if(a3Index+1 < a3Length)
                            a3Index++;
                        else break;
                    }

                    if (a3[a3Index] == a1[a1Index] && (output.Count==0 || output[output.Count - 1] != a1[a1Index] ))
                    {
                        output.Add(a1[a1Index]);
                    }
                }
                a1Index++;
                if(a1Index == a1Length)
                {
                    break;
                }
            }

        }

        #endregion

    }
}
