using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithLocalFunctions
{
    class Program
    {
        //  В С#7 возможность созда­вать методы внутри методов официально называется локальными функциями (local functions).
        static void Main(string[] args)
        {
            Console.WriteLine("Local function returns: {0}", AddWrapper(2,3));
            Console.ReadLine();
        }

        static int AddWrapper(int num1, int num2)
        {
            return Add(num1, num2);
            int Add(int x, int y)
                {
                    // выполнить проверку достоверности
                    return x + y;
                }
        }
    }
}
