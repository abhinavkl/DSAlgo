using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.DP
{
    internal class _01_Fibonacci
    {
        int n { get; set; }
        public _01_Fibonacci()
        {
        }

        public void Solve()
        {
            //int ans= LoopApproach();
            //int ans = FibHead();
        }

        #region loop
        public int LoopApproach()
        {
            int[] series = new int[n+1];
            for(int i=0;i<=n;i++)
            {
                if(i==0 || i == 1)
                {
                    series[i] = i;
                }
                else
                {
                    series[i] = series[i - 1] + series[i - 2];
                }
            }
            return series[n];
        }
        #endregion

        #region Head recursion

        public int FibHead()
        {
            int[] series = new int[n+1];
            return FibHead(series,n);
        }

        int FibHead(int[] series,int index)
        {
            if (index == 0 || index == 1)
                return index;
            else if (series[index] != 0)
                return series[index];
            else
            {
                series[index] = mod(series[index - 1] + series[index-2]);
                return series[index];
            }
        }

        int mod(int num)
        {
            return num % 1000000007;
        }

        #endregion

    }
}
