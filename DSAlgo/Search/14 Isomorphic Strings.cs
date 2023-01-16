using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.Search
{
    internal class _14_Isomorphic_Strings
    {
        string First { get; set; }
        string Second { get; set; }
        public _14_Isomorphic_Strings()
        {
            First = "aaabbbba";
            Second = "bbbaaaba";
        }

        public void Solve()
        {
            bool isomorphic = IsIsomorphic();
        }
        /// <summary>
        /// 
        /// we replace the characters to one another.so we need to check that only. 
        /// 
        /// </summary>
        /// <returns></returns>
        bool IsIsomorphic()
        {
            char[] firstChars = First.ToCharArray();
            char[] secondChars = Second.ToCharArray();
            int[] first = new int[128];
            int[] second = new int[128];

            for (int i = 0; i < 128; i++)
            {
                first[i] = -1;
                second[i] = -1;
            }

            for (int i = 0; i < First.Length; i++)
            {
                if (first[(int)firstChars[i]] == -1 && second[(int)secondChars[i]] == -1)
                {
                    first[(int)firstChars[i]] = (int)secondChars[i];
                    second[(int)secondChars[i]] = (int)firstChars[i];
                }
                else
                {
                    if (first[(int)firstChars[i]] == (int)secondChars[i] && second[(int)secondChars[i]] == (int)firstChars[i])
                    {
                        continue;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }

    }
}
