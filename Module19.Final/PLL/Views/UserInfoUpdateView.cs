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
    public class UserInfoUpdateView
    {
        static UserService userService = Program.userService;

        public static void Show(User user)
        {
            Write("Меня зовут: ");
            user.FirstName = Console.ReadLine();
            Write("Моя фамилия: ");
            user.LastName = Console.ReadLine();
            Write("Ссылка на моё фото: ");
            user.Photo = Console.ReadLine();
            Write("Мой любимый фильм: ");
            user.FavoriteMovie = Console.ReadLine();
            Write("Моя любимая книга: ");
            user.FavoriteBook = Console.ReadLine();

            userService.Update(user);
            WriteLn("Ваш профиль успешно обновлён!", ConsoleColor.Green);
        }
    }
}
