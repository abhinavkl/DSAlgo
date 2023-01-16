using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.Search
{
    internal class _13_Pivot_Element_Left_Sum_Equal_To_Right_Sum
    {
        int[] arr { get; set; }
        int n { get { return arr.Length; } }
        public _13_Pivot_Element_Left_Sum_Equal_To_Right_Sum()
        {
            arr = new int[] { 1, 7, 3, 6, 5, 6 };
        }

        /// <summary>
        /// if for any index left sum= right sum, then it is pivot.
        /// </summary>
        public void Solve()
        {
            int sum = 0;
            
            for(int i = 0; i < n; i++)
            {
                sum+= arr[i];
            }

            int pivotIndex = -1;
            int leftSum = 0;
            int rightSum = sum;

            for (int i = 0; i < arr.Length; i++)
            {
                if (i == 0)
                {
                    leftSum = 0;
                }
                else
                {
                    leftSum += arr[i - 1];
                }
                rightSum -= arr[i];
                if (leftSum == rightSum)
                {
                    pivotIndex=i;
                }
            }
        }

    }
}
