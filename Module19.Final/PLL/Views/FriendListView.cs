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
    public class FriendListView
    {
        static UserService userService = Program.userService;

        public static void Show(User user)
        {
            var friendService = new FriendService();

            var friendsIds = friendService.GetFriendsIds(user.Id);
            if (friendsIds.Count == 0)
                WriteLn("You have no friends yet... Lets add someone!", ConsoleColor.Magenta); 
            else
            {
                WriteLn($"## You have {friendsIds.Count} friends:", ConsoleColor.White);
                foreach (var id in friendsIds)
                {
                    var friend = userService.FindById(id);
                    WriteLn($"\t + {friend.FirstName} {friend.LastName}; EMail: {friend.Email}");
                }
                WriteLn("## End of the list ##", ConsoleColor.White);
            }
        }
    }
}
