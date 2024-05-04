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
    public class FriendAddView
    {
        public static void Show(User user)
        {
            var friendAddData = new FriendAddData();
            var friendService = new FriendService();

            WriteLnBg($" __ ADDITION FRIEND FORM __ ", ConsoleColor.Black, ConsoleColor.Cyan);
            WriteLn($"*- Type email of your new friend:", true);
            friendAddData.friendEmail = ReadLn().Trim();
            friendAddData.userId = user.Id;

            try
            {
                friendService.AddFriend(friendAddData);
                WriteLn("Friend successfully added!", ConsoleColor.Green);
            }
            catch (UserNotFoundException)
            {
                WriteLn($"There is no user with this email!", ConsoleColor.Red);
            }
            catch (UserAlreadyExistsException)
            {
                WriteLn($"You are already befriended!", ConsoleColor.Magenta);
            }
            catch (Exception ex)
            {
                WriteLn($"Friendship error: {ex.Message}", ConsoleColor.Red);
            }
        }
    }
}
