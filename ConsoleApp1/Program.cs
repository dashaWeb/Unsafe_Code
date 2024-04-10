using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public static unsafe void Reverce(int* arr, int size)
        {
            int tmp = 0;
            int j = size - 1;

            for (int i = 0; i < size / 2; i++, j--)
            {
                tmp = *(arr + i);
                *(arr + i) = *(arr + j);
                *(arr + j) = tmp;
            }

            //for (int i = 0; i < size; i++)
            //{
            //	Console.Write($"{arr[i]}  ");
            //}
        }

        static unsafe void Main(string[] args)
        {
            int size = 2;

            int* arr = stackalloc int[size];//new int[] { 1, 2, 3, 4, 5, 6, 7 };
            arr[0] = 1;
            arr[1] = 2;


            //fixed (int* ptr = arr)
            Reverce(arr, size);

            for (int i = 0; i < size; i++)
            {
                Console.Write($"{arr[i]}  ");
            }
        }

    }
}
