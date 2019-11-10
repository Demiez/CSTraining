using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// using static System.Environment;

namespace SimpleCSharpApp
{
    class Program
    {
        /*static void Main(string[] args)
        {
            // Вывести пользователю простое сообщение
            Console.WriteLine("***My first C# App***");
            Console.WriteLine("Hello World'");
            Console.WriteLine();

            //Wait for enter Key to be pressed
            Console.ReadLine();
        }*/
        static int Main(string[] args)
        {
            // Вывести пользователю простое сообщение
            Console.WriteLine("***My first C#23 App***");
            Console.WriteLine("Hello World'");
            Console.WriteLine();
            // Обработать любые входные аргументы, используюя цикл for
            for (int i = 0; i < args.Length; i++)
                Console.WriteLine("Arg: {0}", args[i]);
            // Обработать любые входные аргументы, используюя ключевое слово foreach
            foreach (string arg in args)
                Console.WriteLine("Arg: {0}", arg);

            // Получить аргументы с использованием System.Environment
            // string[] theArgs = GetCommandLineArgs();
            string[] theArgs = Environment.GetCommandLineArgs();
            Console.WriteLine(theArgs);
            foreach (string arg in theArgs)
                Console.WriteLine("Arg: {0}", arg);

            //Используем вспомогательный метод(helper method) внутри класса Program
            ShowEnvironmentDetails();

            // Console.ReadLine();
            // Возвратить произвольный код ошибки
            return -1;
        }

        static void ShowEnvironmentDetails()
        {
            //Вывести информацию о дисковых устройствах и другие интересные детали
            foreach (string drive in Environment.GetLogicalDrives())
                Console.WriteLine("Drive: {0}", drive); // Логические устройства
            Console.WriteLine("OS: {0}", Environment.OSVersion); // Версия операционной системы
            Console.WriteLine("Number of processors: {0}", Environment.ProcessorCount); // Количество процессоров
            Console.WriteLine(".NET Version {0}", Environment.Version); // Версия .NET
            Console.WriteLine("Is System 64bit? {0},{1}", 0, Environment.Is64BitOperatingSystem);
        }
    }
}
