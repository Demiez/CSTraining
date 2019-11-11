using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeConversions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** Fun with Type Conversions ***");
            // добавить 2 переменные типа short(System.Int16) и вывести результат
            short numb1 = 9, numb2 = 10;
            Console.WriteLine($"{numb1} + {numb2} = {Add(numb1,numb2)}");

            // метод Add ожидает 2 переменные типа int, но принимает short, так как переменные short меньше и потеря данных невозможна
            static int Add(int x, int y)
            {
                return x + y;
            }

            TryConversionError(); // используем явное приведение для расширяющего и сужающего преобразований
            ProcessBytes(); // overflow condition - состояние переполнения
            ProcessBytesVer02(); // wrapping within the scope of checked keyword or unchecked

            Console.ReadLine();
        }

        static int Add(int x, int y)
        {
            // используется для примеров
            return x + y;
        }

        static void TryConversionError()
        {
            short numb1 = 30000, numb2 = 30000;

            // Так как неявное (implicit) приведение невозможно, необходим избежать ошибки компиляции нужно применить явное приведение (explicit cast), используя casting operator ()
            // Применяя явное приведение, мы разрешаем потерю данных!
            short answer = (short)Add(numb1, numb2);

            static byte NarrowingAttempt()
            {
                byte myByte = 0;
                int myInt = 200;
                // Explicitly cast the int into a byte (no loss of data).
                myByte = (byte)myInt;
                return myByte;
            }

            Console.WriteLine("{0} + {1} = {2}", numb1, numb2, answer);
            Console.WriteLine("Value of myByte: {0}", NarrowingAttempt());
        }

        static void ProcessBytes()
        {
            byte b1 = 100;
            byte b2 = 250;
            byte sum = (byte)Add(b1, b2);
            // sum should hold the value 350. However, we find the value 94!
            // Данное значение называется значение переполнения (overflow value) => 350 - 256 = 94.
            // Может быть также потеря значимости (underflow value) 
            Console.WriteLine("sum = {0}", sum);
        }

        static void ProcessBytesVer02()
        {
            byte b1 = 100;
            byte b2 = 250;

            // На этот раз сообщить компилятору о необходимости добавления 
            // кода CIL, необходимого для генерации исключений, если возникает 
            // переполнение или потеря значимости => помещаем в scope checked и используем try/catch, чтобы поймать runtime exception: System.OverflowException

            /*try
            {
                byte sum = checked((byte)Add(b1, b2));
                Console.WriteLine("sum = {0}", sum);
            }*/

            // Контекст checked для блока операторов или unchecked
            try
            {
                //unchecked
                checked
                {
                    byte sum = (byte)Add(b1, b2);
                    Console.WriteLine("sum = {0}", sum);
                }
            }

            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
