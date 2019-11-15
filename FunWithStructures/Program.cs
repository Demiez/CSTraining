using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithStructures
{
    #region Simple Structure
    struct Point
    {
        // Declaring data with the public keyword ensures the caller has direct access to the data from a given Point variable(via the dot operator)!!!

        // Поля структуры
        public int X;
        public int Y;

        // Custom constructor
        public Point(int XPos, int YPos)
        {
            X = XPos;
            Y = YPos;
        }

        // Добавить 1 к позиции (X, Y) . 
        public void Increment()
        {
            X++; Y++;
        }
        // Вычесть 1 из позиции (X, Y) . 
        public void Decrement()
        {
            X--; Y--;
        }
        // Отобразить текущую позицию, 
        public void Display()
        {
            Console.WriteLine("X = {0}, Y = {1}", X, Y);
        }
    }
    #endregion
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** A First Look at Structures *****\n");

            // Создать начальную переменную типа Point (initial Point)
            Point myPoint;
            myPoint.X = 349;
            myPoint.Y = 76;
            myPoint.Display();

            // Скорректировать значения X и Y.
            myPoint.Increment();
            myPoint.Display();

            // Для использования переменной типа структуры необходимо обязательно задать значения всем полям!!!
            Point p1;
            p1.X = 10;
            p1.Y = 10;
            p1.Display();

            // При вызове стандартного конструктора структуры каждое поле данных автоматически получает свое стандартное значение:
            Point p2 = new Point();
            p2.Display(); // displays X=0, Y=0;

            // Используем custom constructor
            Point p3 = new Point(32, 22);
            p3.Display(); // displays X=32, Y=22;


            Console.ReadLine();
        }
    }
}
