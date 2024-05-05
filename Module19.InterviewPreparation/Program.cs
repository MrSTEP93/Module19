using System;
using System.Linq;

namespace Module19.InterviewPreparation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //ArrayWhere();
            GetxXx();
        }

        static void ArrayWhere()
        {
            int iterator = 0;
            int[] array = { 1, 2, 3, 4, 5, 6 };
            var filter = array.Where(n => n > 3).Select(_ => iterator++);
            Console.WriteLine(filter.First());
            Console.WriteLine(iterator);
        }

        static void GetxXx()
        {
            Console.WriteLine("creating A...");
            var a = new Storage<int>();
            Console.WriteLine("... created");
            Console.WriteLine("creating B...");
            var b = new Storage<int>();
            Console.WriteLine("... created");
            Console.WriteLine("creating C...");
            var c = new Storage<string>();
            Console.WriteLine("... created");
            Console.WriteLine("creating D...");
            var d = new Storage<byte>();
            Console.WriteLine("... created");
            Console.WriteLine(a.GetX);///что отобразит
            Console.WriteLine(b.GetX);///что отобразит 
            Console.WriteLine(c.GetX);///что отобразит 
            Console.WriteLine(Storage<byte>.X);///что отобразит 
            Console.Read();
        }
    }
    class Storage<T>
    {
        public static int X { get; protected set; }

        static Storage()
        {
            Console.WriteLine("\tStatic ctor begins, X = ", X);
            X++;
            Console.WriteLine("\tStatic ctor ends, X = ", X);
        }

        public Storage()
        {
            Console.WriteLine("\t\t Istance ctor begins, X = ", X);
            Console.WriteLine("\t\t Istance ctor ends, X = ", X);
        }

        public int GetX => X;
    }
}
