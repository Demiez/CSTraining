using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicConsoleIO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** Basic Console Input/Output ***");
            // GetUserData();
            FormatNumericalData();
            DisplayMessage();
            Console.ReadLine();
        }

        private static void GetUserData()
        {
            // Получить информацию об имени и возрасте
            Console.Write("Please enter your name: ");
            string userName = Console.ReadLine();
            Console.Write("Please enter your age: ");
            string userAge = Console.ReadLine();

            // Просто ради забавы изменить цвет переднего фона
            ConsoleColor prevColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;

            // Вывести полученную информацию на консоль
            Console.WriteLine("Hello {0}, your age is {1}", userName, userAge);

            //Восстановить предыдущий цвет переднего плана
            Console.ForegroundColor = prevColor;
        }
        
        static void FormatNumericalData()
        {
            Console.WriteLine("*** The value 99999 in various formats: ***");
            Console.WriteLine("c format {0:c3}", 99999); //денежные значения, по умолчанию 2 знака после нуля
            Console.WriteLine("d9 format {0:d3}", 99999);
            Console.WriteLine("f3 format {0:f3}", 99999);
            Console.WriteLine("n format {0:n}", 99999); // базовое числовое форматирование
            // Обратите внимание, что использование для символа шестнадцатеричного формата 
            // верхнего или нижнего регистра определяет регистр отображаемых символов.
            Console.WriteLine("E format {0:E}", 99999);
            Console.WriteLine("e format {0:e}", 99999);
            Console.WriteLine("X format {0:X}", 99999); // X - шестнадцатеричное форматирование
            Console.WriteLine("x format {0:x}", 99999);
        }

        static void DisplayMessage()
        {
            // Использование string.Format() для форматирования строкового литерала
            string userMessage = string.Format("100000 in hex is {0:x}", 100000);
            // для успешной компиляции требуется ссылка на библиотеку PresentationFramework.dll
            System.Windows.MessageBox.Show(userMessage);
        }
    }
}
