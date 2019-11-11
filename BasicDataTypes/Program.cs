using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics; // здесь определен тип BigInteger

namespace BasicDataTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=> Data Declarations");
            // Локальные переменные объявляются так:
            // типДанных имяПеременной;
            // int myInt;
            // string myString;

            // Локальные переменные объявляются и инициализируются так:
            // типДанных имяПеременной = начальноеЗначение;
            int myInt = 0;

            // Объявлять и присваивать можно также в двух отдельных строках.
            string myString;
            myString = "This is my character data";

            // Можно объявить три переменных одного типа в одной строке.
            bool b1 = true, b2 = false, b3 = b1;

            //  Т.к. ключево слово - сокращенные обозначения полноценных типов из пространства имен System
            // можно использовать полное имя при объявлении
            System.Boolean b4 = false;


            Console.WriteLine("Local variable myInt: {0}", myInt);
            Console.WriteLine("Local variable myString: {0}", myString);
            Console.WriteLine("Local boolean variables: {1},{0},{2}", b1, b2, b3);
            Console.WriteLine("Your data: {0}, {1}, {2}, {3}, {4}, {5}", myInt, myString, b1, b2, b3, b4);
            Console.WriteLine();

            DefaultDeclarations();
            NewingDataTypes();
            // ObjectFunctionality();
            DataTypeFunctionality();
            SystemBooleanType();
            CharFunctionality();
            ParseFromStrings();
            ParseFromStringsWithTryParse();
            UseDatesAndTimes();
            UseBigInteger();
            DigitSeparators();
            BinaryLiterals();

            Console.ReadLine();
        }

        static void DefaultDeclarations()
        {
            Console.WriteLine("=> Default Declarations");
            // литерал default позволяет присваивать переменной стандартное значение ее типа данных
            int myInt = default;
            Console.WriteLine("Default value of int: {0}", myInt);
            Console.WriteLine();
        }

        static void NewingDataTypes()
        {
            Console.WriteLine("=> Using new operator to create variables");
            // Все внутренние типы данных поддерживают default constructor
            bool b = new bool(); // устанавливается в false
            int i = new int(); // устанавливается в 0
            double d = new double(); // устанавливается в 0
            DateTime dt = new DateTime(); // устанавливается в 1/1/0001 12:00:00 AM
            Console.WriteLine("{0}, {1}, {2}, {3} ", b, i, d, dt);
            Console.WriteLine();
        }

        static void ObjectFunctionality()
        {
            Console.WriteLine("=> System Object Functionality");
            // Ключевое слово int языка C# - это в действительности сокращение для 
            // типа System.Int32, который наследует от System.Object следующие члены:
            Console.WriteLine("12.GetHashCode() = {0}", 12.GetHashCode());
            Console.WriteLine("12.Equals (23) = {0}", 12.Equals(23));
            Console.WriteLine("12.ToString () = {0}", 12.ToString());
            Console.WriteLine("12.GetType () = {0}", 12.GetType());
            Console.WriteLine("'string1'.GetType () = {0}", "string1".GetType());
            Console.WriteLine();
        }

        static void DataTypeFunctionality()
        {
            Console.WriteLine("=> Data type Functionality: ");
            Console.WriteLine("Max of int: {0}", int.MaxValue);
            Console.WriteLine("Min of int: {0}", int.MinValue);
            Console.WriteLine("Max of double: {0}", double.MaxValue);
            Console.WriteLine("Min of double: {0}", double.MinValue);
            Console.WriteLine("double.Epsilon: {0}", double.Epsilon);
            Console.WriteLine("double.PositiveInfinity: {0}", double.PositiveInfinity);
            Console.WriteLine("double.NegativeInfinity: {0}", double.NegativeInfinity);
            Console.WriteLine();
        }

        static void SystemBooleanType()
        {
            Console.WriteLine("=> System.Boolean type: ");
            Console.WriteLine("bool.FalseString: {0}", bool.FalseString);
            Console.WriteLine("bool.TrueString: {0}", bool.TrueString);
            Console.WriteLine();
        }

        static void CharFunctionality()
        {
            //  Используя статические ме­тоды System. Char, можно выяснять, является данный символ цифрой, 
            // буквой, знаком пунктуации или чем-то еще
            Console.WriteLine("=> char type Functionality:");
            char myChar = 'a';
            Console.WriteLine("char.IsDigit('a'): {0}", char.IsDigit(myChar));
            Console.WriteLine("char.IsLetter('a'): {0}", char.IsLetter(myChar));
            Console.WriteLine("char.IsWhiteSpace('Hello there', 5): {0}", char.IsWhiteSpace("Hello there", 5));
            Console.WriteLine("char.IsWhiteSpace('Hello there', 6): {0}", char.IsWhiteSpace("Hello there", 6));
            Console.WriteLine("char.IsPunctuation('?'): {0}", char.IsPunctuation('?'));
            Console.WriteLine();
        }

        static void ParseFromStrings()
        {
            Console.WriteLine("=> Data type parsing:");
            bool b = bool.Parse("True");
            Console.WriteLine("Value of b: {0}", b);
            double d = double.Parse("99,884");
            Console.WriteLine("Value of d: {0}", d);
            int i = int.Parse("8");
            Console.WriteLine("Value of i: {0}", i);
            char c = char.Parse("w");
            Console.WriteLine("Value of c: {0}", c);
            Console.WriteLine();
        }

        static void ParseFromStringsWithTryParse()
        {
            /* Если строка может быть преобразована в запрошенный тип данных, метод TryParse() 
            возвращает true и присваивает разобранное значение переменной, переданной методу. 
            В случае невозможности разбора значения перемен­ной присваивается стандартное значение, 
            а метод TryParse() возвращает false.*/
           Console.WriteLine("=> Data type parsing with TryParse:");
            if (bool.TryParse("True", out bool b))
            {
                Console.WriteLine("Value of b: {0}", b);
            }
            // string value = "99,9"; // - проходит
            string value = "Hello"; // - не проходит
            if (double.TryParse(value, out double d))
            {
                Console.WriteLine("Value of d: {0}", d);
            }
            else
            {
                Console.WriteLine("Failed to convert the input ({0}) to a double", value);
            }
            Console.WriteLine();
        }

        static void UseDatesAndTimes()
        {
            Console.WriteLine("=> Dates and Times:");

            // Этот конструктор принимает год, месяц и день
            DateTime dt = new DateTime(2015, 10, 17);

            // Какой это день месяца?
            Console.WriteLine("The day of {0} is {1}", dt.Date, dt.DayOfWeek);

            // Сейчас месяц декабрь
            dt = dt.AddMonths(2);
            Console.WriteLine("Now date is: {0}", dt);
            Console.WriteLine("Daylight savings: {0}", dt.IsDaylightSavingTime());

            // Этот конструктор принимает часы, минуты, секунды
            TimeSpan ts = new TimeSpan(4, 30, 0);
            Console.WriteLine(ts);

            // Вычесть 15 минут из текущего времени и вывести результат
            TimeSpan result = ts.Subtract(new TimeSpan(0, 15, 0));
            Console.WriteLine("Time -15 minutes: {0}", result);
            Console.WriteLine();
        }

        static void UseBigInteger()
        {
            Console.WriteLine("=> Use BigInteger:");
            // для того, чтобы избежать переполнения int, вместо BigInteger используем метод Parse
            BigInteger biggy =
              BigInteger.Parse("9999999999999999999999999999999999999999999999");
            Console.WriteLine("Value of biggy is {0}", biggy);

            Console.WriteLine("Is biggy an even value?: {0}", biggy.IsEven);

            Console.WriteLine("Is biggy a power of two?: {0}", biggy.IsPowerOfTwo);

            BigInteger reallyBig = BigInteger.Multiply(biggy,
              BigInteger.Parse("8888888888888888888888888888888888888888888"));
            Console.WriteLine("Value of reallyBig is {0}", reallyBig);

            // Можно использовать и обычные математические операции
            Console.WriteLine("Usual math operations: {0}", biggy * reallyBig);
            Console.WriteLine();
        }

        static void DigitSeparators()
        {
            Console.WriteLine("=> Use Digit Separators:");
            Console.Write("Integer:");
            Console.Write(123_456);
            Console.Write("Long:");
            Console.WriteLine(123_456_789L);
            Console.Write("Float:");
            Console.WriteLine(123_456.1234F);
            Console.Write("Double:");
            Console.WriteLine(123_456.12);
            Console.Write("Decimal:");
            Console.WriteLine(123_456.12M);
        }

        private static void BinaryLiterals()
        {
            Console.WriteLine("=> Use Binary Literals:");
            Console.WriteLine("Sixteen: {0}", 0b0001_0000); // работает с новым Digit Separator
            Console.WriteLine("Thirty Two: {0}", 0b0010_0000);
            Console.WriteLine("Sixty Four: {0}", 0b0100_0000);
        }
    }
}
