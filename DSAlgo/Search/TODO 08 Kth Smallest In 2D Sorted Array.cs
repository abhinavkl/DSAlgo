using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.Search
{
    internal class _08_Kth_Smallest_In_2D_Sorted_Array
    {
        int[,] arr { get; set; }
        int rowCount { get { return arr.GetLength(0); } }
        int colCount { get { return arr.Length/rowCount; } }
 
        // TODO: 
        public _08_Kth_Smallest_In_2D_Sorted_Array()
        {
            arr = new int[,]
            {
                   { 10, 20, 30, 40 },
                   { 15, 25, 35, 45 },
                   { 25, 29, 37, 48 },
                   { 32, 33, 39, 50 },
                   { 34, 37, 42, 55 }
            };
        }

        public void Solve()
        {
            Matrix[] mini = new Matrix[rowCount];

            for (int i = 0; i < mini.Length; i++)
            {
                mini[i] = new Matrix(arr[i, 0], i, 0);
            }
        }

        void Heapify(Matrix[] mini,int index)
        {
            int left=2*index+1;
            int right=2*index+2;

            int actualMinIndex = index;


        }


    }

    class Matrix
    {
        public Matrix(int value,int rowIndex, int colIndex)
        {
            Value = value;
            RowIndex = rowIndex;
            ColIndex = colIndex;
        }

        int Value { get; set; }
        int RowIndex { get; set; }
        int ColIndex { get; set; }
    }
}
