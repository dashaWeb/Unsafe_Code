using System;

namespace _02_fixed
{
    public class Person : IDisposable
    {
        public string Name { get; set; }
        public int age;
        public int height;

        public Person() { }

        ~Person()
        {
            Console.WriteLine(Name + "Finalizer. Clear resources!");
        }

        public void Dispose()
        {
            Console.WriteLine(Name + "Dispose. Clear resources!");
            GC.SuppressFinalize(this);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            unsafe
            {
                Person person = new Person();
                person.age = 28;
                person.height = 178;
            
                // fixed block
                fixed (int* p = &person.age)
                {
                    if (*p < 30)
                    {
                        *p = 30;
                    }
                }
                Console.WriteLine(person.age); // 30
            }

            unsafe
            {
                int[] nums = { 0, 1, 2, 3, 7, 88 };
                string str = "Hello world";
                fixed (int* p = nums)
                {
                    int third = *(p + 2);       // get 3-th element
                    Console.WriteLine(third);   // 2
                }
                fixed (char* p = str)
                {
                    char fifth = *(p + 4);      // get 5-th element
                    Console.WriteLine(fifth);   // o
                }
            }

            using (Person p = new Person())
            {
                // working with class
            }


            {
                Person p = null;
                try
                {
                    p = new Person();
                    // working with class
                }
                finally
                {
                    p.Dispose();
                }
                Console.ReadKey();
            }
        }
    }
}
