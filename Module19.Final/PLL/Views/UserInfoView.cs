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
    public class UserInfoView
    {
        public static void Show(User user)
        {
            WriteLnBg($"Информация о моем профиле", ConsoleColor.Black, ConsoleColor.Cyan);
            WriteLn($"Мой идентификатор: {user.Id}");
            WriteLn($"Меня зовут: {user.FirstName}");
            WriteLn($"Моя фамилия: {user.LastName}");
            WriteLn($"Мой пароль: {user.Password}");
            WriteLn($"Мой почтовый адрес: {user.Email}");
            WriteLn($"Ссылка на моё фото: {user.Photo}");
            WriteLn($"Мой любимый фильм: {user.FavoriteMovie}");
            WriteLn($"Моя любимая книга: {user.FavoriteBook}");
        }
    }
}
