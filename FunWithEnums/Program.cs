using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithEnums
{
    // .NET type system is composed of classes, structures, enumerations, interfaces, and delegates.
    // Перечисление == enumeration == enum
    // !!! enum != enumerator
    // Перечисления получают свою фун­кциональность от класса System.Enum

    // Специальное перечисление
    enum EmpType
    {
        Manager,        // = 0
        Grunt,          // = 1
        Contractor,     // = 2
        VicePresident   // = 3
    }
    /* В перечислении ЕmpТуре определены четыре именованные константы, которые соот­ветствуют дискретным числовым значениям. По умолчанию первому элементу присва­ивается значение 0, а остальным элементам значения устанавливаются по схеме п+1. */

    /* // Начать нумерацию со значения 102: 
        enum ЕmpТуре
        {
        Manager = 102, 
        Grunt,          // = 103 
        Contractor,     // = 104 
        VicePresident   // = 105
        }
    */
    /* // Значения элементов в перечислении не обязательно должны быть последовательными: 
        enum ЕmpТуре
        {
        Manager = 10, 
        Grunt = 1,
        Contractor = 100,
        VicePresident = 9
        }
    */

    // По умолчанию для хранения значений перечисления используется тип System. Int32
    /* Для элементов можно использовать другой тип, но  каждое значение должно входить в диапазон его допустимых значений: 
        enum ЕmpТуре : byte
    {
        Manager = 10,
        Grunt = 1,
        Contractor = 100,
        VicePresident = 9
    }
    */

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** Fun with Enums ***\n");
            // Создать переменную типа EmpType
            EmpType emp = EmpType.Contractor; // !!! Перед значением нужно указывать имя перечисления
            AskForBonus(emp);

            // Показать тип перечисления (=> FunWithEnums.EmpType)
            Console.WriteLine("GetType() = {0}", emp.GetType()); // для переменной
            Console.WriteLine("typeof() = {0}", typeof(EmpType));// для самого перечисления


            // Вывести текущее строковое имя перечисления
            Console.WriteLine("emp is a {0}.", emp.ToString());
            // Вывести не имя, а значение заданной переменной перечисления => нужно привести ее к текущему типу хранения
            Console.WriteLine("{0} = {1}", emp.ToString(), (int)emp);
            // Вывести тип хранилища для значений перечисления.
            Console.WriteLine("EmpType uses a {0} for storage(using Enum.GetUnderlyingType())",
                Enum.GetUnderlyingType(emp.GetType())); 
            //На этот раз для получения информации о типе используется операция typeof.
            Console.WriteLine("EmpType uses a {0} for storage(using typeof)",
            Enum.GetUnderlyingType(typeof(EmpType)));

            // Enum’s Name-Value Pairs
            EmpType e2 = EmpType.Grunt;
            // Эти типы являются перечислениями из пространства имен System.
            DayOfWeek day = DayOfWeek.Monday;
            ConsoleColor cc = ConsoleColor.Gray;

            EvaluateEnum(e2);
            EvaluateEnum(day);
            EvaluateEnum(cc);

            Console.ReadLine();
        }

        // Перечисления как параметры
        static void AskForBonus(EmpType e)
        {
            switch (e)
            {
                case EmpType.Manager:
                    Console.WriteLine("How about stock options instead?");
                    break;
                case EmpType.Grunt:
                    Console.WriteLine("You have to be kidding?..");
                    break;
                case EmpType.Contractor:
                    Console.WriteLine("You already get enough cash...");
                    break;
                case EmpType.VicePresident:
                    Console.WriteLine("Very Good, Sir!");
                    break;
            }
        }

        // метод, который выводит на консоль пары “имя-значение" из перечисления, переданного в качестве параметра
        static void EvaluateEnum(System.Enum e)
        {
            Console.WriteLine();
            Console.WriteLine("=> Information about {0}", e.GetType().Name);
            Console.WriteLine("Underlying storage type: {0}",
                Enum.GetUnderlyingType(e.GetType()));

            // Получить все пары "имя-значение" для входного параметра.
            Array enumData = Enum.GetValues(e.GetType());
            Console.WriteLine("This enum has {0} members.", enumData.Length);

            // Вывести строковое имя и ассоциированное значение, используя флаг формата D, так как представлены в виде ключ-значение.
            for (int i = 0; i < enumData.Length; i++)
            {
                // Console.WriteLine("Name : {0}, Value: {0:D}", enumData.GetValue(i));
                Console.WriteLine($"Name : {enumData.GetValue(i)}, Value: {enumData.GetValue(i):d}");
            }
            Console.WriteLine();
        }
    }
}
