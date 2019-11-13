using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** Fun with Arrays ***");

            SimpleArrays();
            ArrayInitialization();
            DeclarelmplicitArrays();
            ArrayOfObjects();
            RectMultidimensionalArray(); // прямоугольный многомерный массив - строки имееют одинаковую длину
            JaggedMultidimensionalArray(); // зубчатый (ступенчатый) массив - разная длина строк
            PassAndReceiveArrays();
            SystemArrayFunctionality(); // класс System.Array и его члены

            Console.ReadLine();
        }

        static void SimpleArrays()
        {
            Console.WriteLine("=> Simple Array Collection");
            // Создать массив int содержащий 3 элемента с индексами 0,1,2 и заполнить
            int[] myInts = new int[3]; // по умолчанию содержит нули
            myInts[0] = 100;
            myInts[1] = 200;
            myInts[2] = 300;

            foreach(int i in myInts)
                Console.WriteLine(i);
            Console.WriteLine();

            // Создать массив string, содержащий 100 элементов с индексами 0-99. 
            string[] booksOnDotNet = new string[100]; // по умолчанию содержит пустые строки
            string[] booksOnDotNet01 = new string[5];

            for (int i = 0; i < booksOnDotNet01.Length; i++)
            {
                Console.WriteLine($"{booksOnDotNet01[i]}");
                if (i == booksOnDotNet01.Length - 1)
                {
                    Console.WriteLine("end of array");
                }
            }
            Console.WriteLine();
        }

        static void ArrayInitialization()
        {
            Console.WriteLine("=> Array Initialization");

            // Синтаксис инициализации массива с использованием ключевого слова new.
            string[] stringArray = new string[]
                {"one", "two", "three"};
            Console.WriteLine("StringArray has {0} elements", stringArray.Length);

            // Синтаксис инициализации массива без использования ключевого слова new. 
            bool[] boolArray = { false, false, true };
            Console.WriteLine($"boolArray has {boolArray.Length} elements");

            // Инициализация массива с применением ключевого слова new и указанием размера. 
            int[] intArray = new int[4] { 20, 22, 23, 0 };
            Console.WriteLine("intArray has {0} elements", intArray.Length);
            Console.WriteLine();
        }

        static void DeclarelmplicitArrays()
        {
            Console.WriteLine("=> Implicit Array Initialization.");
            // Инициализация неявно типизированных локальных массивов. Обязательно использование keyword new.

            // Переменная а на самом деле имеет тип int[]. 
            var a = new[] { 1, 10, 100, 1000 };
            Console.WriteLine("a is a: {0}", a.ToString());
            // Переменная b на самом деле имеет тип doublet]. 
            var b = new[] { 1, 1.5, 2, 2.5 };
            Console.WriteLine("b is a: {0}", b.GetType().FullName);
            // Переменная с на самом деле имеет тип string[]. 
            var c = new[] { "hello", null, "world" };
            Console.WriteLine("c is a: {0}", c.ToString());
            Console.WriteLine();
        }

        static void ArrayOfObjects()
        {
            Console.WriteLine("=> Array of Objects");

            // Массив объектов может содержать все что угодно 
            object[] myObjects = new object[4];
            myObjects[0] = 10;
            myObjects[1] = false;
            myObjects[2] = new DateTime(1969, 3, 24);
            myObjects[3] = "Form and Void";
            foreach (object obj in myObjects)
            {
                // Вывести тип и значение каждого элемента в массиве
                Console.WriteLine("Type {0}, Value {1}", obj.GetType(), obj);
            }
            Console.WriteLine();
        }

        static void RectMultidimensionalArray()
        {
            Console.WriteLine("=> Rectangular multidimensional array.");
            // Прямоугольный многомерный массив.

            int[,] myMatrix;
            myMatrix = new int[3, 4];

            // Заполнить массив 3*4
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 4; j++)
                    myMatrix[i, j] = i * j;

            // Вывести содержимое массива (3*4)
            for(int i = 0; i <3; i++)
            {
                for(int j = 0; j < 4; j++ )
                    Console.Write(myMatrix[i,j] + "\t");
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void JaggedMultidimensionalArray()
        {
            Console.WriteLine("=> Jagged multidimensional array.");
            // Зубчатый многомерный массив (т.е. массив массивов).

            // Здесь мы имеем массив из 5 разных массивов
            int[][] myJagArray = new int[5][];

            // Создать зубчатый массив
            for (int i = 0; i < myJagArray.Length; i++)
                myJagArray[i] = new int[i + 7];

            // Вывести все строки (каждый элемент имеет дефолтное значение 0)
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < myJagArray[i].Length; j++)
                    Console.Write(myJagArray [i][j] + "");
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void PrintArray(int[] myInts)
        {
            for(int i = 0; i < myInts.Length; i++)
                Console.WriteLine("Item {0} is {1}", i, myInts[i]);
        }

        static string[] GetStringArray()
        {
            string[] theStrings = { "Hello", "from", "GetStringArray" };
            return theStrings;
        }

        static void PassAndReceiveArrays()
        {
            Console.WriteLine("=> Arrays as params and return values.");
            
            // Передать массив в качестве параметра. 
            int[] ages = { 20, 22, 23, 0 };
            PrintArray(ages);

            // Получить массив как возвращаемое значение
            string[] strs = GetStringArray();
            foreach(string s in strs)
                Console.Write(s + " ");
            Console.WriteLine();
        }

        static void SystemArrayFunctionality()
        {
            Console.WriteLine("=> Working with System.Array");
            /* !!! Many members of System.Array are defined as static members and are, therefore, called at 
            the class level (for example, the Array.Sort() and Array.Reverse() methods)*/
            /* !!! Other members of System.Array(such as the Length property) are
            bound at the object level; thus, you are able to invoke the member directly on the array*/

            // Инициализировать элементы при запуске.
            string[] gothicBands = {"Tones on Tail", "Bauhaus", "Sisters of Mercy" };

            // Вывести имена в порядке их объявления.
            Console.WriteLine("-> Here is the array:"); 
            for (int i = 0; i < gothicBands.Length; i++)
            {
                // Вывести имя.
                Console.Write(gothicBands[i] + ", ");
            }
            Console.WriteLine("\n");

            // Обратить порядок следования элементов
            Array.Reverse(gothicBands);
            Console.WriteLine("-> The reversed array:");
            for (int i = 0; i < gothicBands.Length; i++)
                Console.Write(gothicBands[i] + ", ");
            Console.WriteLine("\n");

            // Удалить все элементы кроме первого
            Console.WriteLine("-> Cleared out all but one:");
            Array.Clear(gothicBands, 1, 2);
            for (int i = 0; i < gothicBands.Length; i++)
                Console.Write(gothicBands[i] + ", ");
            Console.WriteLine("\n");
        }
    }
    }
