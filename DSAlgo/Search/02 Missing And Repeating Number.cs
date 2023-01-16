using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.Search
{
    internal class _02_Missing_And_Repeating_Number
    {
        int[] arr { get; set; }
        int n { get { return arr.Length; } }
        public _02_Missing_And_Repeating_Number()
        {
            arr=new int[] { 7, 3, 4, 5, 5, 6, 2 };
        }

        public void Solve()
        {
            //VisitedIndexApproach();
            XorApproach();
        }

        #region visited index approach
        void VisitedIndexApproach()
        {
            int repeated = 0;

            for (int i = 0; i < n; i++)
            {
                int actual = Math.Abs(arr[i]) - 1;
                if (actual == n)
                    continue;
                else
                {
                    arr[actual] *= -1;
                    if (arr[actual] > 0)
                    {
                        repeated = arr[actual];
                    }
                }
            }

            int missing = 0;
            for (int i = 0; i < n; i++)
            {
                if (arr[i] > 0 && arr[i] != repeated)
                {
                    missing = i + 1;
                    break;
                }
            }

            Console.WriteLine($"missing : {missing} \nrepeated : {repeated} ");
        }
        #endregion

        #region Xor Approach
        void XorApproach()
        {
            int xor = n + 1;

            for (int i = 0; i < n; i++)
            {
                xor ^= (n - i) ^ arr[i];
            }

            int rightMostBit = xor & ~(xor - 1);

            int v1 = 0;
            int v2=0;
            for (int i = 0; i < n; i++)
            {
                if ((arr[i] & rightMostBit)!=0)
                {
                    v1 ^= arr[i];
                }
                else
                {
                    v2 ^= arr[i];
                }
            }

            for(int i = 0; i < n; i++)
            {
                if (arr[i] == v1)
                {
                    Console.WriteLine($"missing : {v2} \nrepeated : {v1} ");
                    break;
                }
                else if (arr[i]==v2)
                {
                    Console.WriteLine($"missing : {v1} \nrepeated : {v2} ");
                    break;
                }
            }

        }
        #endregion

    }
}
