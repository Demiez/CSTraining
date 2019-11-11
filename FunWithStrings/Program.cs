using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; // здесь определен класс StringBuilder
using System.Threading.Tasks;

namespace FunWithStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            BasicStringFunctionality();
            StringConcatenation();
            EscapeChars();
            StringEquality();
            StringEqualitySpecifyingCompareRules();
            StringsAreImmutable();
            StringsAreImmutable2();
            FunWithStringBuilder(); // для понимания чекнуть комменты метода
            StringInterpolation();

            Console.ReadLine();
        }

        static void BasicStringFunctionality()
        {
            Console.WriteLine("=> Basic String Functionality: ");
            string firstName = "Freddy";

            Console.WriteLine("Value of firstName: {0}", firstName);
            Console.WriteLine("firstName has {0} characters", firstName.Length);
            Console.WriteLine("firstName in uppercase: {0}", firstName.ToUpper());
            Console.WriteLine("firstName in lowercase: {0}", firstName.ToLower());
            Console.WriteLine("firstName contains letter 'y'?: {0}", firstName.Contains("y"));
            Console.WriteLine("firstName after replace: {0}", firstName.Replace("dy",""));
            Console.WriteLine();
        }

        static void StringConcatenation()
        {
            Console.WriteLine("=> String Concatenation:");
            string s1 = "Programming the ";
            string s2 = "PsychoDrill (PTP)";
            string s3 = s1 + s2;
            //  при обработке символа + компилятор C# выпускает вызов статического метода String.Concat()
            string s4 = String.Concat(s2, s1);
            Console.WriteLine(s3);
            Console.WriteLine(s4);
            Console.WriteLine();
        }

        static void EscapeChars()
        {
            // Escape Characters - управляющие последовательности (escape sequence),  которые позволяют 
            // уточнять то, как символьные данные должны быть представлены в потоке вывода
            Console.WriteLine("=> Escape characters:\a");
            string strWithTabs = "Model\tColor\tSpeed\tPet Name\a ";
            Console.WriteLine(strWithTabs);
            Console.WriteLine("Everyone loves \"Hello World\"\a ");
            Console.WriteLine("C:\\MyApp\\bin\\Debug\a ");
            // Adds a total of 4 blank lines (then beep again!).
            Console.WriteLine("All finished.\n\n\n\a ");

            // Verbatim Strings (дословные строки) с  добавлением к строковому литералу префикса @
            // то есть мы отключаем escape sequences и отображаем строку как есть.
            Console.WriteLine(@"Using verbatim strings in 
                                    this
                                            long line");
            Console.WriteLine(@"C:\System\App32\app32.exe");
            Console.WriteLine();
        }

        static void StringEquality()
        {
            // Хотя тип string - это ссылочный тип (refference type), операции равенства для него
            // были переопределены так,  чтобы можно было сравнивать значения объектов string, а 
            // не ссылки на объекты в памяти

            Console.WriteLine("=> String equality:");
            string s1 = "Hello!";
            string s2 = "Yo!";
            Console.WriteLine("s1 = {0}", s1);
            Console.WriteLine("s2 = {0}", s2);
            Console.WriteLine();
            // Test these strings for equality.
            Console.WriteLine("s1 == s2: {0}", s1 == s2);
            Console.WriteLine("s1 == Hello!: {0}", s1 == "Hello!");
            Console.WriteLine("s1 == HELLO!: {0}", s1 == "HELLO!");
            Console.WriteLine("s1 == hello!: {0}", s1 == "hello!");
            Console.WriteLine("s1.Equals(s2): {0}", s1.Equals(s2));
            Console.WriteLine("Yo.Equals(s2): {0}", "Yo!".Equals(s2));
            Console.WriteLine();
        }

        static void StringEqualitySpecifyingCompareRules()
        {
            Console.WriteLine("=> String equality Different Compare Rules:");
            string s1 = "Hello!";
            string s2 = "HELLO!";
            Console.WriteLine("s1 = {0}", s1);
            Console.WriteLine("s2 = {0}", s2);
            Console.WriteLine();

            // Проверить результаты изменения стандартных правил сравнения
            Console.WriteLine("Default rules: s1={0}, s2={1} s1.Equals(s2): {2}", s1, s2, s1.Equals(s2));
            /*... используем перегруженные методы overloads of methods (когда класс имеет одинаковые методы, но
            с разными аргументами, а также перечисление(enumeration) StringComparison */
            Console.WriteLine("Ignore case: s1.Equals(s2, StringComparison.OrdinalIgnoreCase): {0}",s1.Equals(s2, StringComparison.OrdinalIgnoreCase));
            Console.WriteLine("Ignore case, Invarariant Culture: s1.Equals(s2, StringComparison.InvariantCultureIgnoreCase): {0}", s1.Equals(s2, StringComparison.InvariantCultureIgnoreCase));
            Console.WriteLine();
            Console.WriteLine("Default rules: s1={0},s2={1} s1.IndexOf(\"E\"): {2}", s1, s2, s1.IndexOf("E"));
            Console.WriteLine("Default rules: s1={0},s2={1} s2.IndexOf(\"E\"): {2}", s1, s2, s2.IndexOf("E"));
            Console.WriteLine("Ignore case: s1.IndexOf(\"E\", StringComparison.OrdinalIgnoreCase): {0}", s1.IndexOf("E", StringComparison.OrdinalIgnoreCase));
            Console.WriteLine("Ignore case, Invarariant Culture: s1.IndexOf(\"E\", StringComparison.InvariantCultureIgnoreCase): {0}", s1.IndexOf("E", StringComparison.InvariantCultureIgnoreCase));
            Console.WriteLine();
        }

        static void StringsAreImmutable()
        {
            // Установить начальное значение для строки
            string s1 = "This is my string.";
            Console.WriteLine("s1 = {0}", s1);

            //Преобразована ли строка в верхний регистр?
            string upperString = s1.ToUpper();
            Console.WriteLine("upperString = {0}", upperString);

            //Нет, строка s1 осталась в том же виде
            Console.WriteLine("s1 = {0}", s1);
        }

        static void StringsAreImmutable2()
        {
            // Check ILDASM for details, in CIL there were 2 string objects created
            string s2 = "My other string.";
            s2 = "New string value";
            Console.WriteLine("s2 = {0}", s2);
        }

        static void FunWithStringBuilder()
        {
            // Класс StringBuilder находится в пространстве имен System.Text
            /* Уникальность класса в том, что при вызове его членов производится прямое изменение внутренних символьных данных объекта (делая его более эффектив­ным) без получения копии данных в модифицированном формате */
            /*  При создании экзем­пляра (instance) StringBuilder начальные значения объекта могут быть заданы через один из множества конструкторов. */

            Console.WriteLine("=> Using the StringBuilder:");
            StringBuilder sb = new StringBuilder("**** Fantastic Games ****");
            sb.Append("\n"); //  можно добавлять строки в конец внутреннего буфера, а также заменять или удалять любые символы
            sb.AppendLine("Half Life");
            sb.AppendLine("Morrowind");
            sb.AppendLine("Deus Ex" + "2");
            sb.AppendLine("System Shock");
            Console.WriteLine(sb.ToString());
            sb.Replace("2", " Invisible War");
            Console.WriteLine(sb.ToString());
            Console.WriteLine("sb has {0} chars.", sb.Length);
            Console.WriteLine();
        }

        static void StringInterpolation()
        {
            //  Интерполяция строк позволяет напрямую внедрять сами переменные, а не помещать их в спи­сок с разделителями - запятыми.

            int age = 4;
            string name = "Soren";
            // Using curly bracket syntax with numerical placeholders.
            string greeting = string.Format("\tHello {0} you are {1} years old.", name.ToUpper(), age);
            Console.WriteLine(greeting);

            // Using string interpolation - начало строки с префикса $
            string greeting2 = $"\tHello {name.ToUpper()} you are {age} years old.";
            Console.WriteLine(greeting2);
        }
    }
}
