using Module19.Final.BLL.Exceptions;
using Module19.Final.BLL.Models;
using Module19.Final.BLL.Services;
using Module19.Final.PLL.Views;
using System;
using System.ComponentModel.DataAnnotations;
using static ConsoleHelper_50.Helper_50;

namespace Module19.Final
{
    internal class Program
    {
        public static UserService userService = new UserService();
        public static User user;

        static void Main(string[] args)
        {
            WriteLnBg("Welcome from MrSTEP's unsocial club!", ConsoleColor.Black, ConsoleColor.Cyan);
            WelcomeView.Show();

            WriteLn("Press Enter to exit application...");
            ReadLn();
        }
    }
}
