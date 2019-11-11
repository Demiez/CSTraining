using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplicitlyTypedLocalVars
{
    class Program
    {
        static void Main(string[] args)
        {
            DeclareImplicitVars();
            LinqQueryOverInts();

            Console.ReadLine();
        }

        static void DeclareImplicitVars()
        {
            // Неявно типизированные локальные переменные 
            // объявляются следующим образом:
            // var имяПеременной = начальноеЗначение;
            var myInt = 0;
            var myBool = true;
            var myString = "Time, marches on...";

            // Вывести имена лежащих в основе типов
            Console.WriteLine("myInt is a: {0}", myInt.GetType().Name); // Вывод типа myInt
            Console.WriteLine("myBool is a: {0}", myBool.GetType().Name); // Вывод типа myBool
            Console.WriteLine("myString is a: {0}", myString.GetType().FullName); // Вывод типа myBool
        }

        static void LinqQueryOverInts()
        {
            Console.WriteLine("=> Linq Query");

            int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 8 };
            // LINQ query!
            var subset = from i in numbers where i < 10 select i;
            Console.Write("Values in subset: ");
            foreach (var i in subset)
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine();
            // Hmm...what type is subset?
            Console.WriteLine("subset is a: {0}", subset.GetType().Name);
            Console.WriteLine("subset is defined in: {0}", subset.GetType().Namespace);
        }
    }
}
