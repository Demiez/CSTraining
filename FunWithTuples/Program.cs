using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithTuples
{
    struct Point
    {
        // Поля структуры, 
        public int X;
        public int Y;
        // Специальный конструктор, 
        public Point(int XPos, int YPos)
        {
            X = XPos;
            Y = YPos;
        }
        public (int XPos, int YPos) Deconstruct() => (X, Y);
    }
    class Program
    {
        // Кортеж(tuple) или n-ка - упорядоченная и оконченная совокупность элементов
        static void Main(string[] args)
        {
            Console.WriteLine("*** Fun with Tuples ***\n");
            // ItemX notation:
            (string, int, string) values = ("a", 5, "c"); // === var values = ("a", 5, "c");
            Console.WriteLine($"First value of tuple: {values.Item1}");
            Console.WriteLine($"Second value of tuple: {values.Item2}");
            Console.WriteLine($"Third value of tuple: {values.Item3}\n");

            AddSpecificNamesToItems();
            InferTupleNames();
            ReturnTupleInsteadOut(); // Return tuple instead of using out parameter
            DiscardWithTuple(); // to discard using underscore '_' placeholder\

            Point p = new Point(20, 30);
            var pointValues = p.Deconstruct(); // Deconstructing properties of tuple
            Console.WriteLine("Returned item 1 from structure: {0}", pointValues.XPos);
            Console.WriteLine("Returned item 2 from structure: {0}", pointValues.YPos);

            Console.ReadLine();
        }

        static void AddSpecificNamesToItems()
        {
            (string FirstLetter, int TheNumber, string SecondLetter) 
                valuesWithNames = ("x", 10, "y"); // === var valuesWithNames2 = (FirstLetter: "a", TheNumber: 5, SecondLetter: "c");
            Console.WriteLine($"First item: {valuesWithNames.FirstLetter}");
            Console.WriteLine($"Second item: {valuesWithNames.TheNumber}");
            Console.WriteLine($"Third item: {valuesWithNames.SecondLetter}\n");
        }

        static void InferTupleNames() // вывести имена кортежей
        {
            Console.WriteLine("=> Inferred Tuple Names"); 
            var foo = new { Prop1 = "first", Prop2 = "second" };
            Console.WriteLine("Type of foo: {0}", foo.GetType());
            var bar = (foo.Prop1, foo.Prop2);
            Console.WriteLine("Type of bar: {0}", bar.GetType());
            Console.WriteLine($"{bar.Prop1}, {bar.Prop2}\n");
        }

        static (int a, string b, bool c) FillTheseValues()
        {
            return (9, "Enjoy your string.", true);
        }

        static void ReturnTupleInsteadOut()
        {
            Console.WriteLine("=> Returned tuple insted of out parameter");
            var samples = FillTheseValues();
            Console.WriteLine($"Int is: {samples.a}");
            Console.WriteLine($"String is: {samples.b}");
            Console.WriteLine($"Boolean is: {samples.c}\n");
        }

        static void DiscardWithTuple()
        {
            Console.WriteLine("=> Discard tuple item");
            (string, string, string) fullName = ("Philip", "F", "Japikse");
            var (first, _, last) = fullName;
            Console.WriteLine($"{first}:{last}\n");
        }
    }
}
