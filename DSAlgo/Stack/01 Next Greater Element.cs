using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.Stack
{
    internal class _01_Next_Greater_Element
    {
        int[] arr { get; set; }
        int n { get { return arr.Length; } }
        public _01_Next_Greater_Element()
        {
            arr = new int[] { 6, 8, 0, 1, 3 };
        }

        public void Solve()
        {
            int[] nextGreater= new int[n];

            Stack<int> stack = new Stack<int>();

            //we add each index. line 54 also.
            stack.Push(0);
            for(int i= 1; i < n; i++)
            {
                if (stack.Count > 0)
                {
                    //we pop the elements in the stack either to make nextGreater of that index to current element if current is greater or add it back index for future.
                    int index=stack.Pop();

                    while (arr[index] < arr[i])
                    {
                        nextGreater[index] = arr[i];

                        if (stack.Count > 0)
                        {
                            //same as 30.
                            index = stack.Pop();
                        }
                        else
                        {
                            break;
                        }
                    }

                    //explained in 30.
                    if (arr[index] > arr[i])
                        stack.Push(index);

                }
                
                //explained at 24.
                stack.Push(i);
            }

            //for all the elements which indexes are in still in stack, in above iterations we didn't find next greater elements.
            while(stack.Count > 0)
            {
                int index = stack.Pop();
                nextGreater[index] = -1;
            }
        }

    }
}
