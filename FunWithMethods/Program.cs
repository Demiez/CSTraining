using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithMethods
{
    class Program
    {
        // static возвращаемыйТип ИмяМетода(список параметров) { /* Реализация */ }
        static void Main(string[] args)
        {
            Console.WriteLine("*** Fun with methods ***\n");

            // Pass two variables in by value.
            int x = 9, y = 10;
            Console.WriteLine("Before call: X: {0}, Y: {1}", x, y);
            Console.WriteLine("Answer is: {0}", Add(x, y));
            Console.WriteLine("After call: X: {0}, Y: {1}", x, y);
            Console.WriteLine();

            // Присваивать начальные значения локальным переменным, используемым как выходные параметры, не обязательно при условии, что они впервые используются впервые в таком качестве.
            // int ans;
            // Add(90, 90, out ans);
            // Версия C# 7 позволяет объявлять параметры out в вызове метода.
            AddWithOut(90, 90, out int ans);
            Console.WriteLine("90 + 90 = {0}", ans);
            Console.WriteLine();

            int i; string str; bool b;
            FillTheseValues(out i, out str, out b);
            Console.WriteLine("Int is: {0}", i);
            Console.WriteLine("String is: {0}", str);
            Console.WriteLine("Boolean is: {0}", b);
            Console.WriteLine();

            string str1 = "Flip";
            string str2 = "Flop";
            Console.WriteLine("Before: {0} {1}", str1, str2);
            SwapStrings(ref str1, ref str2);
            Console.WriteLine("After: {0} {1}", str1, str2);
            Console.WriteLine();

            #region Ref locals and params
            string[] stringArray = { "one", "two", "three" };
            int pos = 1;
            Console.WriteLine("=> Use simple return");
            Console.WriteLine($"Before: {stringArray[0]}, {stringArray[1]}, {stringArray[2]}");
            var output = SimpleReturn(stringArray, pos);
            output = "new";
            Console.WriteLine($"After: {stringArray[0]}, {stringArray[1]}, {stringArray[2]}");
            Console.WriteLine();
            #endregion

            #region Ссылочные локальные переменные и возвращаемые ссылочные значения
            Console.WriteLine("=> Use Ref Return");
            Console.WriteLine("Before: {0}, {1}, {2}", stringArray[0],stringArray[1], stringArray[2]);

            ref var refOutput = ref SampleRefReturn(stringArray, pos); //  Вызов метода также требует применения ключевого слова ref — для возвращаемой переменной и для самого вызова метода
            refOutput = "new";
            Console.WriteLine("After: {0}, {1}, {2}", stringArray[0], stringArray[1], stringArray[2]);
            Console.WriteLine();
            #endregion

            // Используем модификатор params
            Console.WriteLine("=> Use params Modifier");
            // передать список значений double, разделенный запятыми...
            double average;
            average = CalculateAverage(4.0, 3.2, 5.7, 64.22, 87.2);
            Console.WriteLine("Average of data is: {0}", average);
            //... или передать массив значений
            double[] data = { 4.0, 3.2, 5.7 };
            average = CalculateAverage(data);
            Console.WriteLine("Average of data from [] is: {0}", average);
            // среднее из 0 равно 0
            Console.WriteLine("Average of data from 0 is: {0}", CalculateAverage());
            Console.WriteLine();

            // Optional parameters - необязательные параметры
                //!!! Опциональные параметры должны всегда помещаться в конец сигнатуры метода!
            Console.WriteLine("=> Use optional parameters");
            EnterLogData("Oh no! Grid can't find data");
            EnterLogData("Oh no! Grid can't find data", "CFO");
            Console.WriteLine();

            // Named arguments
            // !!!  при вызове метода ПОЗИЦИОННЫЕ параметры должны находиться ПЕРЕД всеми ИМЕНОВАННЫМИ параметрами. 
            Console.WriteLine("=> Use named arguments");
            DisplayFancyMessage(message: "Wow! Very Fancy indeed!", 
                textColor: ConsoleColor.DarkRed, 
                backgroundColor: ConsoleColor.White);
            DisplayFancyMessage(backgroundColor: ConsoleColor.Green, 
                message: "Testing...",
                textColor: ConsoleColor.DarkBlue);

            Console.ReadLine();
        }
        static int Add(int x, int y)
        {
            Console.WriteLine("=> static int Add(int x, int y) : ");
            //По умолчанию аргументы передаются по значению, passed by value
            int ans = x + y;
            // Вызывающий код не увидит эти изменения, т.к. модифицируется копия исходных данных, 
            // х = 10000;
            // у = 88888;
            return ans;
        }
        static void AddWithOut(int x, int y, out int ans)
        {
            Console.WriteLine("=> static void AddWithOut (int x, int y, out int ans) : ");
            ans = x + y;
        }

        static void FillTheseValues(out int a, out string b, out bool c)
        {
            // Возвращение множества выходных параметров,
            a = 9;
            b = "Enjoy your string.";
            c = true;
        }

        // Reference parameters.
        public static void SwapStrings(ref string s1, ref string s2)
        {
            string tempStr = s1;
            s1 = s2;
            s2 = tempStr;
        }

        // Возвращает значение по позиции в массиве.
        public static string SimpleReturn(string[] strArray, int position)
        {
            return strArray[position];
        }

        public static ref string SampleRefReturn(string[] strArray, int position)
        {
            // !!! Объявление метода должно включать ref
            // !!! взамен return [возвращаемое значение] метод возвращает return ref [возвращаемая ссылка]
            return ref strArray[position];
        }

        static double CalculateAverage (params double[] values)
        {
            // Возвращение среднего из некоторого количества значений double
            Console.WriteLine("You sent me {0} doubles", values.Length);
            double sum = 0;
            if (values.Length == 0)
                return sum;
            for (int i = 0; i < values.Length; i++)
                sum += values[i];
            return (sum / values.Length);
        }

        static void EnterLogData (string message, string owner = "Programmer")
        {
            Console.Beep();
            Console.WriteLine("Error: {0}", message);
            Console.WriteLine("Owner of Error: {0}", owner);
        }

        static void DisplayFancyMessage (
            ConsoleColor textColor = ConsoleColor.Blue, 
            ConsoleColor backgroundColor = ConsoleColor.White, 
            string message = "Test message")
        {
            // Сохранить старые цвета для их восстановления после вывода сообщения.
            ConsoleColor oldTextColor = Console.ForegroundColor;
            ConsoleColor oldbackgroundColor = Console.BackgroundColor;

            // Установить новые цвета и вывести сообщение
            Console.ForegroundColor = textColor;
            Console.BackgroundColor = backgroundColor;
            Console.WriteLine(message);

            // Восстановить предыдущие цвета
            Console.ForegroundColor = oldTextColor;
            Console.BackgroundColor = oldbackgroundColor;
        }
    }
}
