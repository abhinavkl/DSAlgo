﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.Search
{
    internal class _11_Floor_In_Sorted_Array
    {
        int[] arr { get; set; }
        int n { get { return arr.Length; } }
        int key;
        public _11_Floor_In_Sorted_Array()
        {
            arr = new int[] { 2778, 6916, 7794, 8336, 5387, 493, 6650, 1422, 2363, 28, 8691, 60, 7764, 3927, 541, 3427, 9173, 5737, 5212, 5369, 2568, 6430, 5783, 1531, 2863, 5124, 4068, 3136, 3930, 9803, 4023, 3059, 3070, 8168, 1394, 8457, 5012, 8043, 6230, 7374, 4422, 4920, 3785, 8538, 5199, 4325, 8316, 4371, 6414, 3527, 6092, 8981, 9957, 1874, 6863, 9171, 6997, 7282, 2306, 926, 7085, 6328, 337, 6506, 847, 1730, 1314, 5858, 6125, 3896, 9583, 546, 8815, 3368, 5435, 365, 4044, 3751, 1088, 6809, 7277, 7179, 5789, 3585, 5404, 2652, 2755, 2400, 9933, 5061, 9677, 3369, 7740, 13, 6227, 8587, 8095, 7540, 796, 571, 1435, 379, 7468, 6602, 98, 2903, 3318, 493, 6653, 757, 7302, 281, 4287, 9442, 3866, 9690, 8445, 6620, 8441, 4730, 8032, 8118, 8098, 5772, 4482, 676, 710, 8928, 4568, 7857, 9498, 2354, 4587, 6966, 5307, 4684, 6220, 8625, 1529, 2872, 5733, 8830, 9504, 20, 8271, 3369, 9709, 6716, 6341, 8150, 7797, 724, 2619, 2246, 2847, 3452, 2922, 3556, 2380, 7489, 7765, 8229, 9842, 2351, 5194, 1501, 7035, 7765, 125, 4915, 6988, 5857, 3744, 6492, 2228, 8366, 9860, 1937, 1433, 2552, 6438, 9229, 3276, 5408, 1475, 6122, 8859, 4396, 6030, 1238, 8236, 3794, 5819, 4429, 6144, 1012, 5929, 9530, 8777, 2405, 4444, 5764, 4614, 4539, 8607, 6841, 2905, 4819, 5129, 689, 7370, 7918, 9918, 6997, 3325, 7744, 9471, 2184, 8491, 5500, 9773, 6726, 5645, 5591, 7506, 8140, 2955, 9787, 7670, 8083, 8543, 8465, 198, 9508, 9356, 8805, 6349, 8612, 3623, 7829, 9300, 7344, 5747, 5569, 4341, 5423, 3312, 3811, 7606, 1802, 5662, 3731, 4879, 1306, 9321, 8737, 9445, 8627, 8523, 3466, 6709, 3417, 8283, 3259, 2925, 7638, 2063, 5625, 2601, 2037, 3453, 1900, 9380, 5551, 7469, 72, 974, 7132, 3882, 4931, 8934, 5895, 8661, 164, 7200, 7982, 8900, 2997, 2960, 3774, 2814, 9669, 7191, 1096, 2927, 6467, 5085, 1341, 2091, 7685, 3377, 5543, 5937, 9108, 7446, 9757, 9180, 8419, 6888, 9413, 3349, 2173, 1660, 2010, 2337, 5211, 6343, 7588, 8207, 9302, 7714, 7373, 5322, 1256, 4820, 4600, 7722, 9905, 5940, 9812, 3941, 5668, 1706, 6229, 1128, 9151, 5985, 6659, 3921, 9225, 2423, 7270, 1397, 4082, 5631, 85, 9293, 1973, 7673, 3851, 7626, 5386, 1223, 9300, 6641, 6043, 3899, 714, 2299, 6191, 525, 2591, 8210, 8582, 8820, 9337, 7733, 1156, 5995, 8005, 380, 4770, 5274, 1777, 8851, 7256, 1861, 8143, 5580, 5885, 1994, 3206, 7622, 9568 };
            key = 887;
        }

        public void Solve()
        {
            Sort(arr.Length);
            int[] findFloorsFor = new int[] { 12, 13,27,28,9956,9957,9958 };
            foreach(var num in findFloorsFor)
            {
                key = num;
                int floor = Floor(0, arr.Length - 1);
                if (floor != -1)
                    Console.WriteLine($"floor of {key} is {arr[floor]}");
                else
                    Console.WriteLine($"floor for {key} not exists");
            }
        }

        int Floor(int start,int end)
        {
            if (arr[end]<=key)
            {
                return end;
            }
            while (start < end)
            {
                int mid = (end - start) / 2 + start;
                if (arr[mid] == key)
                    return mid;
                else if (arr[mid] < key && arr[mid + 1] > key)
                    return mid;
                else if (arr[mid] < key)
                    start = mid + 1;
                else
                    end = mid;
            }
            return arr[start] == key ? start : start -1;
        }

        void Sort(int n)
        {
            for(int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(n,i);
            }

            for(int i = n - 1; i >= 0; i--)
            {
                Swap(i,0);
                Heapify(i, 0);
            }

        }

        void Heapify(int lastElementIndex,int index)
        {
            int left = 2 * index + 1;
            int right = 2 * index + 2;

            int actualIndex = index;

            if (left<lastElementIndex && arr[left] > arr[actualIndex])
                    actualIndex = left;

            if (right < lastElementIndex && arr[right] > arr[actualIndex])
                    actualIndex = right;

            if (actualIndex != index)
            {
                Swap(actualIndex,index);
                Heapify(lastElementIndex,actualIndex);
            }

        }

        void Swap(int sf,int st)
        {
            if (arr[sf] != arr[st])
            {
                arr[sf] ^= arr[st];
                arr[st] ^= arr[sf];
                arr[sf] ^= arr[st];
            }
        }

    }
}
