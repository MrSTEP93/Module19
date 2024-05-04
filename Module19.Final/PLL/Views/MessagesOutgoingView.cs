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
    public class MessagesOutgoingView
    {
        static UserService userService = Program.userService;

        public static void Show(User user)
        {
            MessageService messageService = new MessageService();

            var messages = messageService.GetOutgoingMessagesByUserId(user.Id);
            WriteLn($"## You have {messages.Count()} sent messages: ##", ConsoleColor.White);
            foreach (var message in messages)
            {
                var recipient = userService.FindById(message.RecipientId);
                WriteLn($"\tid={message.Id}, recipient={recipient.LastName} {recipient.FirstName}, text=\"{message.Content}\"");
            }
            WriteLn("## End of the list ##", ConsoleColor.White);
        }
    }
}
