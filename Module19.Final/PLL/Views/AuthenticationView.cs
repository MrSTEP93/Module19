using Module19.Final.BLL.Exceptions;
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
    public class AuthenticationView
    {
        static UserService userService = Program.userService;
        static User user;

        public static void Show()
        {
            var authenticationData = new UserAuthenticationData();

            WriteLn("Введите почтовый адрес:", true);
            authenticationData.Email = Console.ReadLine();

            WriteLn("Введите пароль:", true);
            authenticationData.Password = Console.ReadLine();

            try
            {
                user = userService.Authenticate(authenticationData);
                WriteLn("Успешная авторизация! Добро пожаловать в систему.", ConsoleColor.Green);
                MainMenuView.Show(user);
            }
            catch (WrongPasswordException)
            {
                WriteLn("Неверный пароль!", ConsoleColor.Red);
            }
            catch (UserNotFoundException)
            {
                WriteLn("Пользователь не найден!", ConsoleColor.Red);
            }
        }
    }
}
