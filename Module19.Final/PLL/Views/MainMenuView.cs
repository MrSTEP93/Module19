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
    public class MainMenuView
    {
        static UserService userService = Program.userService;

        public static void Show(User user)
        {
            while (true)
            {
                /*
                WriteLnBg("Выберите действие: ", ConsoleColor.Black, ConsoleColor.DarkCyan);
                WriteLn("* Просмотреть информацию о моём профиле (нажмите 1)");
                WriteLn("* Редактировать мой профиль (нажмите 2)");
                WriteLn("* Добавить в друзья (нажмите 3)");
                WriteLn("* Написать сообщение (нажмите 4)");
                WriteLn("* Выйти из профиля (нажмите 5)");
                */
                
                WriteLn($"\nВаши сообщения: Входящие :({user.IncomingMessages.Count()}), Исходящие: ({user.OutgoingMessages.Count()})");
                WriteLnBg("Выберите действие (введите нужную цифру): ", ConsoleColor.Black, ConsoleColor.DarkCyan);
                WriteLn("* (1) Просмотреть информацию в моём профиле");
                WriteLn("* (2) Редактировать мой профиль");
                WriteLn("* (3) Добавить в друзья");
                WriteLn("* (4) Написать сообщение");
                WriteLn("* (5) Просмотреть входящие сообщения");
                WriteLn("* (6) Просмотреть исходящие сообщения");
                WriteLn("* (7) Выйти из приложения", true);

                string keyValue = ReadLn()?.Trim();

                if (keyValue == "7") break;

                switch (keyValue)
                {
                    case "1":
                        {
                            UserInfoView.Show(user);
                            break;
                        }
                    case "2":
                        {
                            UserInfoUpdateView.Show(user);
                            break;
                        }
                    case "4":
                        {
                            MessageSendingView.Show(user);
                            break;
                        }
                    case "5":
                        {
                            UserMessagesIncomingView.Show(user);
                            break;
                        }
                    case "6":
                        {
                            UserMessagesOutgoingView.Show(user);
                            break;
                        }
                }
                Console.ResetColor();
            }
        }
    }
}
