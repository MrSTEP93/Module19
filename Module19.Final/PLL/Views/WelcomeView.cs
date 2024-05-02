using Module19.Final.BLL.Models;
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
            WriteLnBg("Введите команду: ", ConsoleColor.Black, ConsoleColor.DarkCyan);
            WriteLn("v Войти в профиль (нажмите 1)");
            WriteLn("> Зарегистрироваться (нажмите 2)", true);

            switch (ReadLn().Trim())
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
            }
        }
    }
}
