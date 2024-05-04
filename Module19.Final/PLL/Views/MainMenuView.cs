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
                WriteLn($"\nВаши сообщения: Входящие: ({user.IncomingMessages.Count()}), Исходящие: ({user.OutgoingMessages.Count()})");
                WriteLnBg("Выберите действие (введите нужную цифру): ", ConsoleColor.Black, ConsoleColor.DarkCyan);
                WriteLn("* (1) Просмотреть информацию в моём профиле");
                WriteLn("* (2) Редактировать мой профиль");
                WriteLn("* (3) Сделать ничто");
                WriteLn("* (4) Написать сообщение");
                WriteLn("* (5) Просмотреть входящие сообщения");
                WriteLn("* (6) Просмотреть исходящие сообщения");
                WriteLn("* (7) Добавить друга");
                WriteLn("* (8) Посмотреть список друзей");
                WriteLn("* (0) Выйти из приложения", true);

                string keyValue = ReadLn()?.Trim();

                if (keyValue == "0") break;

                switch (keyValue)
                {
                    case "1":           //Просмотреть информацию в моём профиле
                        {
                            UserInfoView.Show(user);
                            break;
                        }
                    case "2":           //Редактировать мой профиль
                        {
                            UserInfoUpdateView.Show(user);
                            break;
                        }
                    case "3":           //Сделать ничто
                        {
                            // Здесь могла быть вьюшка со списком всех пользователей, и чтобы можно было ввести цифру и выбрать,
                            // с кем взаимодействовать (посмотреть профиль, добавить в друзья, отправить сообщение).
                            // Так же, аналогичное можно было бы сделать в списке друзей, но ...
                            // Но я итак сильно отстаю по учебному курсу, поэтому не буду углубляться в это, пойду дальше
                            break;
                        }
                    case "4":           // Написать сообщение
                        {
                            MessageSendingView.Show(user);
                            break;
                        }
                    case "5":           //Просмотреть входящие сообщения
                        {
                            MessagesIncomingView.Show(user);
                            break;
                        }
                    case "6":           //Просмотреть исходящие сообщения
                        {
                            MessagesOutgoingView.Show(user);
                            break;
                        }
                    case "7":           //Добавить друга
                        {
                            FriendAddView.Show(user);
                            break;
                        }
                    case "8":           //Посмотреть список друзей
                        {
                            FriendListView.Show(user);
                            break;
                        }
                }
                Console.ResetColor();
            }
        }
    }
}
