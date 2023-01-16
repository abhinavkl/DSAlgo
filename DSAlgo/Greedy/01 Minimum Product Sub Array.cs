using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.Greedy
{
    internal class _01_Minimum_Product_Sub_Array
    {
        int[] arr { get; set; }
        int n { get { return arr.Length; } }
        public _01_Minimum_Product_Sub_Array()
        {
            arr = new int[] { -1, -1, -2, 4, 3 };
        }
        public void Solve()
        {
            int countOfNeg = 0;
            int countOfPositives = 0;
            
            for(int i = 0; i < n; i++)
            {
                if (arr[i] < 0)
                    countOfNeg++;
                else if (arr[i]>0)
                    countOfPositives++;
            }
            
            if(countOfNeg==0)
            {
                int firstMin = int.MinValue;
                int secondMin=int.MinValue;

                for(int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] >= 0)
                    {
                        secondMin = firstMin;
                        firstMin = arr[i];
                    }
                }
                if(firstMin!=int.MinValue && secondMin != int.MinValue)
                {
                    Console.WriteLine($"Minimum is : {firstMin*secondMin} ");
                }
                else
                {
                    Console.WriteLine("Minimum does not exist");
                }
            }
            else
            {
                if (countOfNeg > 0)
                {
                    int maxNeg = int.MinValue;
                    int prod = 1;

                    for(int i = 0; i < n; i++)
                    {
                        if (arr[i] != 0)
                        {
                            prod = prod * arr[i];
                            if (arr[i]<0 && maxNeg < arr[i])
                            {
                                maxNeg = arr[i];
                            }
                        }
                    }
                    if (countOfNeg % 2 == 0)
                    {
                        prod = prod / maxNeg;
                    }
                }
            }


        }

    }
}
