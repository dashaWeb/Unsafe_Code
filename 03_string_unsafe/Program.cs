using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_string_unsafe
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "It's a imutable string";
            string copy = str;

            Console.WriteLine("It's a imutable string");
            ReverseString(str); //olleH
            Console.WriteLine("Reversed!");
            Console.WriteLine("It's a imutable string");

            Console.WriteLine("str: " + str); // olleH
            Console.WriteLine("copy: " + copy); // Hello
            
            if (str == copy)
            {
                Console.WriteLine("str == copy");
            }
           
        }
        static unsafe void ReverseString(string str)
        {
            int i = 0;
            int j = str.Length - 1;

            fixed (char* fstr = str)
            {
                while (i < j)
                {
                    char temp = fstr[j];

                    fstr[j--] = fstr[i];
                    fstr[i++] = temp;
                }
            }
        }
    }
}
