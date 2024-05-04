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
    public class WelcomeView
    {
        public static void Show()
        {
            WriteLnBg("\nВведите команду: ", ConsoleColor.Black, ConsoleColor.DarkCyan);
            WriteLn("v Войти в профиль (нажмите 1)");
            WriteLn("> Зарегистрироваться (нажмите 2)", true);

            switch (ReadLn()?.Trim())
            {
                case "1":
                    {
                        AuthenticationView.Show();
                        break;
                    }

                case "2":
                    {
                        RegistrationView.Show();
                        break;
                    }
                case "3":
                    {
                        UserService userService = new UserService();
                        var userRegData = new UserRegistrationData()
                        {
                            Email = "nomail@nohost.no",
                            Password = "123"
                        };
                        userService.Register(userRegData);
                        break;

                        /// Благодаря юнит-тестам выяснилось, что поле, которое было не заполнено, это не тоже самое, что пустое значение, считанное из консоли.
                        /// (какая неожиданность).      Тут же выяснилось, что точка останова не срабатывает, если метод запускается из теста.
                        /// Поэтому, пришлось добавить этот недокументированный кейс, чтобы быстро передать в метод Register() данные с незаполненными полями, 
                        /// по которым я уже смог провести отладку и понять, в чем же было дело. В целом, проблема была ни о чем 
                        /// и не могла повториться при работе с консолью, но я смог защититься и от такого вида исключения (NRE)
                        /// 
                        /// ОПЫТ
                        /// 
                        /// опыт
                    }
            }
        }
    }
}
