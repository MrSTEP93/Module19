using System;

namespace Module19.Final
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome from MrSTEP's unsocial club!");
            while (true)
            {
                Console.Write("Type your name: ");
                string userName = Console.ReadLine();
                if (ValidateName(userName)) 
                    break;
                Console.WriteLine("Username must contains a correct value!!!");

            }
            Console.Write("Type your password: ");

        }

        private static bool ValidateName(string userName)
        {
            if (string.IsNullOrEmpty(userName))
                return false;
            else
                return true;
        }
    }
}
