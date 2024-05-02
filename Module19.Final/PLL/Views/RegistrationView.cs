using Module19.Final.BLL.Models;
using Module19.Final.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleHelper_50.Helper_50;

namespace Module19.Final.PLL.Views
{
    public class RegistrationView
    {
        static UserService userService = Program.userService;

        public static void Show()
        {
            var userRegData = new UserRegistrationData();

            WriteLn("You need to be registered now");
            Write($"\t Type your First Name: ", ConsoleColor.Blue);
            userRegData.FirstName = ReadLn();
            Write($"\t Type your Last Name: ", ConsoleColor.Blue);
            userRegData.LastName = ReadLn();
            Write($"\t Type your EMail: ", ConsoleColor.Blue);
            userRegData.Email = ReadLn();
            Write($"\t Type your Password (7+ symbols): ", ConsoleColor.Blue);
            userRegData.Password = ReadLn();

            try
            {
                userService.Register(userRegData);
                WriteLn("Registration completed. Nice to see you!", ConsoleColor.Green);
            }
            catch (ArgumentNullException ex)
            {
                WriteLn("Invalid registration data: " + ex.Message, ConsoleColor.Red);
            }
            catch (ArgumentException ex)
            {
                WriteLn("Registration failed: " + ex.Message, ConsoleColor.DarkCyan);
            }
            catch (Exception exception)
            {
                WriteLn("Registration failed: " + exception.Message, ConsoleColor.DarkCyan);
            }
            WelcomeView.Show();
        }
    }
}
