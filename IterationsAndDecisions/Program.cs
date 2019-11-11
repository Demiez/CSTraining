using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterationsAndDecisions
{
    class Program
    {
        static void Main(string[] args)
        {
            ForLoopExample();
            ForEachLoopExample();
            // WhileLoopExample();
            // DoWhileLoopExample();
            IfElseExample();
            ExecuteIfElseUsingConditionalOperator(); // ternary expression
            // SwitchExample();
            // SwitchStringExample();
            // SwitchOnEnumExample();
            // ExecutePatternMatchingSwitch();
            ExecutePatternMatchingSwitchWithWhen();

            Console.ReadLine();
        }

        static void ForLoopExample()
        {
            // базовый пример
            // Обратите внимание, что переменная i видима только в контексте цикла for. 
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Number is: {0}", i);
            }
            // Здесь переменная i больше видимой не будет.
        }

        static void ForEachLoopExample()
        {
            string[] carTypes = { "Ford", "BMW", "Yugo", "Honda" };
            foreach (string car in carTypes)
                Console.WriteLine(car);

            int[] myInts = { 10, 20, 30, 40 };
            foreach (int number in myInts)
                Console.WriteLine(number);
        }

        static void WhileLoopExample()
        {
            string userIsDone = "";
            while(userIsDone.ToLower() != "yes")
            {
                Console.WriteLine("In while loop");
                Console.Write("Are you done? [yes] [no]: ");
                userIsDone = Console.ReadLine();
            }
        }
        
        static void DoWhileLoopExample()
        {
            string userIsDone = "";
            do
            {
                Console.WriteLine("In do/while loop");
                Console.Write("Are you done? [yes] [no]: ");
                userIsDone = Console.ReadLine();
            } while (userIsDone.ToLower() != "yes");
        }

        static void IfElseExample()
        {
            string stringData = "Му textual data";
            // Недопустимо, т.к. свойство Length возвращает int, а не bool 
            // if (stringData.Length)

            if (stringData.Length > 0) // правильно, т.к возвращает true или false
            {
                // Строка длиннее 0 символов
                Console.WriteLine("string is greater than 0 characters");
            }
            else
            {
                // Строка не длиннее 0 символов
                Console.WriteLine("string is not greater than 0 characters");
            }
            Console.WriteLine();
        }

        private static void ExecuteIfElseUsingConditionalOperator()
        {
            // Only assignment, call, increment, decrement, and new object expressions can be used as statements”
            string stringData = "My textual data";
            Console.WriteLine(stringData.Length > 0
              ? "string is greater than 0 characters"
              : "string is not greater than 0 characters");
            Console.WriteLine();
        }

        static void SwitchExample()
        {
            Console.WriteLine("1 [C#] 2 [VB]");
            Console.Write("Please, pick your language preference: ");
            string langChoice = Console.ReadLine();
            int n = int.Parse(langChoice);
            
            switch (n)
            {
                /* Язык C# требует, чтобы каждый блок case (включая default), который содержит 
                исполняемые операторы, завершался оператором return, break или goto во избежание
                сквозного прохода по блокам. */
                case 1:
                    Console.WriteLine("Good choice, C# is a fine language.");
                    break;
                case 2:
                    Console.WriteLine("VB: OOP, multithreading, and more!");
                    break;
                default:
                    Console.WriteLine("Well... good luck with that!");
                    break;
            }
        }

        static void SwitchStringExample()
        {
            Console.WriteLine("C# or VB");
            Console.Write("Please, pick your language preference: ");
            string langChoice = Console.ReadLine();

            switch (langChoice) //оценивает данные string
            {
                case "C#":
                    Console.WriteLine("Good choice, C# is a fine language.");
                    break;
                case "VB":
                    Console.WriteLine("VB: OOP, multithreading, and more!");
                    break;
                default:
                    Console.WriteLine("Well... good luck with that!");
                    break;
            }
        }

        static void SwitchOnEnumExample()
        {
            Console.Write("Enter your favorite day of the week: ");
            DayOfWeek favDay;
            try
            {
                favDay = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), Console.ReadLine());
                Console.WriteLine(favDay);

            }
            catch (Exception)
            {
                Console.WriteLine("Bad input!");
                return;
            }
            switch (favDay)
            {
                case DayOfWeek.Sunday: // cases можно комбинировать
                case DayOfWeek.Saturday:
                    Console.WriteLine("Weekend!!!");
                    break;
                case DayOfWeek.Monday:
                    Console.WriteLine("Another day, another dollar");
                    break;
                case DayOfWeek.Tuesday:
                    Console.WriteLine("At least it is not Monday");
                    break;
                case DayOfWeek.Wednesday:
                    Console.WriteLine("A fine day.");
                    break;
                case DayOfWeek.Thursday:
                    Console.WriteLine("Almost Friday...");
                    break;
                case DayOfWeek.Friday:
                    Console.WriteLine("Yes, Friday rules!");
                    break;
            }
            Console.WriteLine();
        }

        static void ExecutePatternMatchingSwitch()
        {
            Console.WriteLine("1 [Integer (5)], 2 [String (\"Hi\")], 3 [Decimal (2.5)]");
            Console.Write("Please choose an option: ");
            string userChoice = Console.ReadLine();
            object choice;

            //This is a standard constant pattern switch statement to set up the example
            // Стандартный оператор switch, в котором применяется сопоставление с образцом с константами 
            switch (userChoice)
            {
                case "1":
                    choice = 5;
                    break;
                case "2":
                    choice = "Hi";
                    break;
                case "3":
                    choice = 2.5;
                    break;
                default:
                    choice = 5;
                    break;
            }
            Console.WriteLine($"Choice: {choice}");
            //This is new the pattern matching switch statement
            // Новый оператор switch, в котором применяется сопоставление с образцом с типами 
            switch (choice)
            {
                // !!! Также в каждом кейсе мы присваиваем переменную и можем ее вывести !!!
                case int i:
                    Console.WriteLine("Your choice is an integer: {0}", i);
                    break;
                case string s:
                    Console.WriteLine("Your choice is a string: {0}", s);
                    break;
                case double d:
                    Console.WriteLine("Your choice is a decimal: {0}", d);
                    break;
                default:
                    Console.WriteLine("Your choice is something else");
                    break;
            }
            Console.WriteLine();
        }

        static void ExecutePatternMatchingSwitchWithWhen()
        {
            Console.WriteLine("1 [C#] 2[VB]");
            Console.Write("Please pick your language preference: ");
            object langChoice = Console.ReadLine();
            // Console.WriteLine("Converted = {0}, {1}", int.TryParse(langChoice.ToString(), out int c), c);
            var choice = int.TryParse(langChoice.ToString(), out int c) ? c : langChoice;

            //  в дополнение к проверке типа производится проверка на совпадение преобра­зованного типа через when
            switch (choice)
            {
                case int i when i == 1:
                case string s when s.Equals("C#", StringComparison.OrdinalIgnoreCase):
                    Console.WriteLine("Good choice, C# is a fine language.");
                    break;
                case int i when i == 2:
                case string s when s.Equals("VB", StringComparison.OrdinalIgnoreCase):
                    Console.WriteLine("VB: OOP, multithreading, and more!");
                    break;
                default:
                    Console.WriteLine("Well... good luck with that!");
                    break;
            }
            Console.WriteLine();
        }
    }
}
