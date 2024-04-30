using System;
using System.ComponentModel.DataAnnotations;

namespace Module19.Final
{
    internal class Program
    {

        enum DataType
        {
            surname,
            name,
            password,
            email
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome from MrSTEP's unsocial club!");
            AskUserData(DataType.surname);
            AskUserData(DataType.name);
            AskUserData(DataType.password);
            AskUserData(DataType.email);
            
        }

        private static void AskUserData(DataType dataType)
        {
            while (true)
            {
                Console.Write($"Type your {dataType}: ");
                string userInput = Console.ReadLine();
                if ((dataType == DataType.name) || (dataType == DataType.surname))
                    if (ValidateName(userInput))
                        break;
                    else
                        Console.WriteLine($"{dataType} must contains a correct value!!!");
                if (dataType == DataType.password)
                    if (ValidatePass(userInput))
                        break;
                    else
                        Console.WriteLine("Password must be longer than 7 symbols");
                if (dataType == DataType.email) 
                    if (ValidateEmail(userInput))
                        break;
                    else
                        Console.WriteLine("Please, type correct email");
            }
        }

        private static bool ValidateName(string userName)
        {
            if (string.IsNullOrEmpty(userName))
                return false;
            else
                return true;
        }

        private static bool ValidatePass(string password)
        {
            if (password.Length < 8)
                return false;
            else
                return true;
        }

        private static bool ValidateEmail(string email)
        {
            if (new EmailAddressAttribute().IsValid(email))
                return true;
            else
                return false;
        }
    }
}
