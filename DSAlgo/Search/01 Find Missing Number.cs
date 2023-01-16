using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.Search
{
    internal class _01_Find_Missing_Number
    {
        int[] arr { get; set; }
        int n { get { return arr.Length; } }
        public _01_Find_Missing_Number()
        {
            arr = new int[] { 1, 2, 4, 6, 3, 7, 8 };
        }

        public void Solve()
        {
            //VisitedIndexApproach();
            //XorApproach();
            SumSubApproach();
        }

        #region Visited Index approach
        void VisitedIndexApproach()
        {
            for(int i = 0; i < n; i++)
            {
                int actual = Math.Abs(arr[i]) - 1;
                if (actual == n)
                    continue;
                else
                    arr[actual] *= -1;
            }

            int missing = n+1;
            for(int i = 0; i < n; i++)
            {
                if (arr[i] > 0)
                {
                    missing = i + 1;
                    break;
                }
            }
            Console.WriteLine($"missing : {missing} ");
        }
        #endregion

        #region Xor Approach
        /// <summary>
        /// to apply xor till n+1, better initiate xor=n+1.
        /// </summary>
        void XorApproach()
        {
            int xor = n+1;
            for (int i = 0; i < n; i++)
            {
                xor ^= (n-i) ^ arr[i];
            }

            Console.WriteLine($"missing : {xor} ");
        }
        #endregion

        #region Sum and Sub Approach
        /// <summary>
        /// 
        ///  sum=1
        ///  counter will sum from 1 to n for 0 to n-1 indexes
        ///  arr[i] will remove 1 to n+1 exc missing missing number
        ///  sum = 1 + ( 1 to n ) - ( 1 to n+1 - x)
        ///  sum = 1 + ( 1 to n ) - ( 1 to n ) - n+1 + x  
        ///  sum = 1 - n -1 + x
        ///  sum = x-n
        ///  
        ///  so better start sum as n+1
        /// 
        /// </summary>
        void SumSubApproach()
        {
            int sum = n+1;
            int counter = 1;

            for (int i = 0; i < n; i++)
            {
                sum += counter++ - arr[i];
            }

            Console.WriteLine($"missing : {sum} ");

        }

        #endregion

    }
}
