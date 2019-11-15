using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueAndReferenceTypes
{
    #region Simple Structure
    struct Point
    {
        // Fields of the structure
        public int X;
        public int Y;

        // Custom constructor
        public Point(int XPos, int YPos)
        {
            X = XPos;
            Y = YPos;
        }

        // Methods
        public void Increment()
        {
            X++; Y++;
        }
        public void Decrement()
        {
            X--; Y--;
        }
        public void Display()
        {
            Console.WriteLine("X = {0}, Y = {1}", X, Y);
        }
    }
    #endregion

    #region Simple Class with the same members as in Simple Structure
    class PointRef
    {
        // !!! Классы всегда являются ссылочными типами!!!
        // Содержит те же самые члены, что и в структуре Point...
        public int X;
        public int Y;

        // Custom constructor
        public PointRef(int XPos, int YPos)
        {
            X = XPos;
            Y = YPos;
        }

        // Methods
        public void Increment()
        {
            X++; Y++;
        }
        public void Decrement()
        {
            X--; Y--;
        }
        public void Display()
        {
            Console.WriteLine("X = {0}, Y = {1}", X, Y);
        }
    }
    #endregion

    #region Value Type containing Ref Type
    class ShapeInfo
    {
        public string infoString;
        
        public ShapeInfo(string info) // Custom constructor
        {
            infoString = info;
        }
    }

    struct Rectangle
    {
        // Структура Rectangle содержит член ссылочного типа
        public ShapeInfo RectInfo;

        public int RectTop, RectLeft, RectBottom, RectRight;

        // Custom constructor
        public Rectangle(string info, int top, int left, int bottom, int right)
        {
            RectInfo = new ShapeInfo(info);
            RectTop = top; RectBottom = bottom;
            RectLeft = left; RectRight = right;
        }

        public void Display()
        {
            Console.WriteLine("String = {0}, Top = {1}, Bottom = {2}, " +
            "Left = {3}, Right = {4}",
            RectInfo.infoString, RectTop, RectBottom, RectLeft, RectRight);
        }
    }
    #endregion
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** Value Types and Reference Types ***\n");

            ValueTypeAssignment();
            ReferenceTypeAssignment();
            ValueTypeContainingRefType();

            Console.ReadLine();
        }

        // Присваивание двух внутренних типов значений дает в результате две независимые переменные в стеке
        static void ValueTypeAssignment()
        {
            Console.WriteLine("Assigning value types: \n");
            Point p1 = new Point(10, 10);
            Point p2 = p1;

            // Вывести значения обеих переменных Point, 
            p1.Display();
            p2.Display();

            //Изменить pl.X и снова вывести значения переменных.Значение р2.Х не изменилось. 
            p1.X = 100;
            Console.WriteLine("\n=> Changed pl.X\n");
            p1.Display();
            p2.Display();
            Console.WriteLine();
        }

        static void ReferenceTypeAssignment()
        {
            // equals to method ValueTypeAssignment except the use of PointRef class
            Console.WriteLine("Assigning reference types: \n");
            PointRef p1 = new PointRef(10, 10);
            PointRef p2 = p1;

            p1.Display();
            p2.Display();

            //Изменить pl.X и снова вывести значения переменных.Значение р2.Х ИЗМЕНИЛОСЬ тк ссылочный тип. 
            p1.X = 100;
            Console.WriteLine("\n=> Changed pl.X\n");
            p1.Display();
            p2.Display();
            Console.WriteLine();
        }

        static void ValueTypeContainingRefType()
        {
            // Создать первую переменную Rectangle
            Console.WriteLine("-> Creating r1");
            Rectangle r1 = new Rectangle("First Rect", 10, 10, 50, 50);

            // Присвоить новой переменной Rectangle переменную rl.
            Console.WriteLine("-> Assigning r2 to r1");
            Rectangle r2 = r1;

            // Изменить некоторые значения в r2.
            Console.WriteLine("-> Changing values of r2");
            r2.RectInfo.infoString = "This is new info";
            r2.RectBottom = 4444;

            // Вывести значения из обеих переменных Rectangle, 
            r1.Display();
            r2.Display();
            Console.WriteLine();
        }
    }
}
