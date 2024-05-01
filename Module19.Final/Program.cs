using Module19.Final.BLL.Exceptions;
using Module19.Final.BLL.Models;
using Module19.Final.BLL.Services;
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

            while (true)
            {
                WriteLnBg("Введите команду: ", ConsoleColor.Black, ConsoleColor.DarkCyan);
                WriteLn("_Войти в профиль (нажмите 1)");
                WriteLn("_Зарегистрироваться (нажмите 2)", true);

                switch (ReadLn())
                {
                    case "1":
                        {
                            if (StartAuthentication())
                                ShowMenu();
                            break;
                        }

                    case "2":
                        {
                            StartRegistration();
                            break;
                        }
                }
            }
        }


        public static void WriteLnBg(string message, ConsoleColor textColor, ConsoleColor backgroundColor)
        {
            Console.BackgroundColor = backgroundColor;
            WriteLn(message, textColor);
            Console.BackgroundColor = ConsoleColor.Black;
        }

        static bool StartAuthentication()
        {
            var authenticationData = new UserAuthenticationData();

            WriteLn("Введите почтовый адрес:", true);
            authenticationData.Email = Console.ReadLine();

            WriteLn("Введите пароль:", true);
            authenticationData.Password = Console.ReadLine();

            try
            {
                user = userService.Authenticate(authenticationData);
                return true;
            }
            catch (WrongPasswordException)
            {
                WriteLn("Неверный пароль!", ConsoleColor.Red);
                return false;
            }
            catch (UserNotFoundException)
            {
                WriteLn("Пользователь не найден!", ConsoleColor.Red);
                return false;
            }
        }

        static void StartRegistration()
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
        }

        static void ShowMenu()
        {
            WriteLn($"Вы успешно вошли в социальную сеть! Добро пожаловать {user.FirstName}", ConsoleColor.Green);
            while (true)
            {
                WriteLnBg("Выберите действие: ", ConsoleColor.Black, ConsoleColor.DarkCyan);
                WriteLn("_Просмотреть информацию о моём профиле (нажмите 1)");
                WriteLn("_Редактировать мой профиль (нажмите 2)");
                WriteLn("_Добавить в друзья (нажмите 3)");
                WriteLn("_Написать сообщение (нажмите 4)");
                WriteLn("_Выйти из профиля (нажмите 5)");

                switch (Console.ReadLine())
                {
                    case "1":
                        {
                            WriteLn($"Информация о моем профиле");
                            WriteLn($"Мой идентификатор: {user.Id}");
                            WriteLn($"Меня зовут: {user.FirstName}");
                            WriteLn($"Моя фамилия: {user.LastName}");
                            WriteLn($"Мой пароль: {user.Password}");
                            WriteLn($"Мой почтовый адрес: {user.Email}");
                            WriteLn($"Ссылка на моё фото: {user.Photo}");
                            WriteLn($"Мой любимый фильм: {user.FavoriteMovie}");
                            WriteLn($"Моя любимая книга: {user.FavoriteBook}");
                            break;
                        }
                    case "2":
                        {
                            Console.Write("Меня зовут:");
                            user.FirstName = Console.ReadLine();
                            Console.Write("Моя фамилия:");
                            user.LastName = Console.ReadLine();
                            Console.Write("Ссылка на моё фото:");
                            user.Photo = Console.ReadLine();
                            Console.Write("Мой любимый фильм:");
                            user.FavoriteMovie = Console.ReadLine();
                            Console.Write("Моя любимая книга:");
                            user.FavoriteBook = Console.ReadLine();

                            userService.Update(user);
                            WriteLn("Ваш профиль успешно обновлён!", ConsoleColor.Green);
                            break;
                        }
                }
            }
        }
    }
}
