using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodOverloading
{
    class Program
    {
        //   Когда определяется набор идентично именованных методов, которые отличаются друг от друга количеством (или типами) параметров, то говорят, что такой метод был перегружен.
        static void Main(string[] args)
        {
            Console.WriteLine("*** Fun with Method Overloading ***\n");

            // Вызов int-версии Add()
            Console.WriteLine("Calling int-version of Add: {0}", Add(10, 10));

            // Вызов long-версии Add() using the new digit separator
            Console.WriteLine("Calling long-version of Add: {0}", Add(
                900_000_000_000, 
                900_000_000_000));

            // Вызов double-версии Add()
            Console.WriteLine("Calling double-version of Add: {0}", Add(4.3, 4.4));

            Console.ReadLine();
        }

        // Overloaded method Add
        static int Add(int x, int y) => x + y;

        static double Add(double x, double y)
        { return x + y; }

        static long Add(long x, long y)
        { return x + y; }
    }
}
