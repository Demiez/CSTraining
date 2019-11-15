using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullableTypes
{
    // Язык C# поддерживает концепцию типов данных, допускающих значение null (nullable data types). 
    // Т.Е. допускающий null тип может представлять все значения лежащего в основе типа плюс null

    // Чтобы определить переменную типа, допускающего null, необходимо добавить к имени интересующего типа данных суффикс в виде знака вопроса(?) - работает только с value types

    class DatabaseReader
    {
        // Nullable data field.
        public int? numericValue = null;
        public bool? boolValue = true;

        // Note the nullable return type.
        public int? GetIntFromDatabase()
        { return numericValue; }

        // Note the nullable return type.
        public bool? GetBoolFromDatabase()
        { return boolValue; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Ошибка на этапе компиляции!
            // Типы значений не могут быть установлены в null!
            // bool myBool = null;
            // int myInt = null;

            // Все в порядке! Строки являются ссылочными типами, 
            string myString = null;

            Console.WriteLine("***** Fun with Nullable Data *****\n");
            DatabaseReader dr = new DatabaseReader();

            // Получить значение int из "базы данных"
            int? i = dr.GetIntFromDatabase();
            if (i.HasValue)
            {
                Console.WriteLine("Value of 'i' is: {0}", i.Value);
            }
            else
                Console.WriteLine("Value of 'i' is undefined.");

            // Получить значение bool из "базы данных"
            bool? b = dr.GetBoolFromDatabase();
            if (b != null)
                Console.WriteLine("Value of 'b' is: {0}", b.Value);
            else
                Console.WriteLine("Value of 'b' is undefined.");
            Console.WriteLine();

            // If the value from GetIntFromDatabase() is null, assign local variable to 100.
            // ?? ===  null coalescing operator
            int myData = dr.GetIntFromDatabase() ?? 100;
            Console.WriteLine("Value of myData: {0}", myData);
            Console.WriteLine();

            //null-условная операция (Null Conditional Operator) - проверяем на null
            OldNullTesterMethod(null);
            NewTesterMethod(null); //  задействована null-условная опера­ция(знак вопроса, находящийся после типа переменной, но перед операцией доступа к члену)

            Console.ReadLine();
        }

        static void LocalNullableVanables()
        {
            //  система обозначений в форме суффикса ? представляет собой сокраще­ние для создания экземпляра обобщенного типа структуры System.Nullable <T>

            // Определить несколько локальных переменных, допускающих null.
            int? nullablelnt = 10;
            double? nullableDouble = 3.14;
            bool? nullableBool = null;
            char? nullableChar = 'a';
            int?[] arrayOfNullablelnts = new int?[10];
            // Ошибка! Строки являются ссылочными типами!
            // string? s = "oops";
        }

        static void LocalNullableVariablesUsingNullable()
        {
            // Определить несколько типов, допускающих null, с применением Nullable<T>. 
            Nullable<int> nullablelnt = 10;
            Nullable<double> nullableDouble = 3.14;
            Nullable<bool> nullableBool = null;
            Nullable<char> nullableChar = 'a';
            Nullable<int>[] arrayOfNullablelnts = new Nullable<int>[10];
        }

        static void OldNullTesterMethod(string[] args)
        {
            // Перед доступом к данным массива мы должны проверить его на равенство null! 
            if (args != null)
            {
                Console.WriteLine($"OldNullTester: You sent me {args.Length} arguments.");
            }
            else
                Console.WriteLine($"OldNullTester: it was null!");
        }

        static void NewTesterMethod(string[] args)
        {
            // We should check for null before accessing the array data!
            Console.WriteLine($"You sent me {args?.Length} arguments.");
            Console.WriteLine($"Using coalescing operator '??': You sent {args?.Length ?? 0} arguments.");
        }
    }
}
