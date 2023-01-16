using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.Search
{
    internal class _04_No_of_One_In_Sorted_Binary_Array
    {
        int[] arr { get; set; }
        int n { get { return arr.Length; } }
        public _04_No_of_One_In_Sorted_Binary_Array()
        {
            arr = new int[] { 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1 , 1};
            //arr = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            //arr = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        }

        public void Solve()
        {
            BinarySolve();
        }

        #region Binary Solve
        void BinarySolve()
        {
            int startPos = OneStartPosition(0,n-1);
            int count= n - startPos;
            Console.WriteLine($" count : {count} ");
        }

        int OneStartPosition(int start,int end)
        {
            if (start < end)
            {
                int mid=(end-start)/2+start;

                if (arr[mid] == 1)
                {
                    return OneStartPosition(start,mid);
                }
                else
                {
                    return OneStartPosition(mid+1,end);
                }
            }
            else
            {
                if (arr[start] == 0)
                    return start + 1;
                else
                    return start;
            }
        }

        #endregion

    }
}
