using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefTypeValTypeParams
{
    #region Simple Person Class
    class Person
    {
        public string personName;
        public int personAge;

        // Constructors
        public Person (string name, int age)
        {
            personName = name;
            personAge = age;
        }
        public Person() { }
        public void Display()
        {
            Console.WriteLine("Name: {0}, Age: {1}", personName, personAge);
        }
    }
    #endregion
    class Program
    {
        static void Main(string[] args)
        {
            // Передача ссылочных типов по значению.
            Console.WriteLine("***** Passing Person object by value *****");
            Person fred = new Person("Fred", 12);
            Console.WriteLine("\nBefore by value call, Person is: ");
            fred.Display();

            SendAPersonByValue(fred);
            Console.WriteLine("\nAfter by value call, Person is:");
            fred.Display();
            Console.WriteLine();

            // Передача ссылочных типов по ссылке.
            Person mel = new Person("Mel", 23);
            Console.WriteLine("Before by ref call, Person is:");
            mel.Display();

            SendAPersonByReference(ref mel);
            Console.WriteLine("After by ref call, Person is:");
            mel.Display();
            Console.WriteLine();

            Console.ReadLine();
        }

        static void SendAPersonByValue (Person p)
        {
            // Изменить значение возраста в р? - изменить данные объекта можно
            p.personAge = 99;

            // Увидит ли вызывающий код это изменение? -  Нельзя лишь переустанавливать ссылку так, чтобы она указывала на какой - то другой объект.
            p = new Person("Nikki", 99);
        }
        
        static void SendAPersonByReference(ref Person p)
        {
            // Изменить некоторые данные в р. 
            p.personAge = 555;

            // р теперь указывает на новый объект в куче! 
            p = new Person("Nikki", 999);
        }
    }
}
