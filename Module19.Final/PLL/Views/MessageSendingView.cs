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
    public class MessageSendingView
    {
        public static void Show(User user)
        {
            var messageService = new MessageService();
            var messageData = new MessageSendingData();

            WriteLnBg($" __ SENDING MESSAGE FORM __ ", ConsoleColor.Black, ConsoleColor.Cyan);
            WriteLn($"*- Type recepient email (addressee):", true);
            messageData.RecipientEmail = ReadLn().Trim();
            WriteLn("*- Type message text:", true);
            messageData.Content = ReadLn();
            messageData.SenderId = user.Id;

            try
            {
                messageService.SendMessage(messageData);
                WriteLn("Message successfuly delivered!", ConsoleColor.Green);
            }
            catch (Exception ex)
            {
                WriteLn($"Sending message failed: {ex.Message}", ConsoleColor.Red);
            }

        }

        /*
        private void OldShow()
        {
            var messageService = new MessageService();

            WriteLnBg($" __ SENDING MESSAGE FORM __ ", ConsoleColor.Black, ConsoleColor.Cyan);
            WriteLn($"*- Type recepient email (addressee):", true);
            string recipientAddress = ReadLn();
            int recipientId = 0;
            try
            {
                recipientId = messageService.ValidateAddress(recipientAddress);
            }
            catch (UserNotFoundException)
            {
                WriteLn("There is no user with this email!", ConsoleColor.Red);
            }
            if (recipientId != 0)
            {
                WriteLn("*- Type message text:", true);
                string messageText = ReadLn();
                bool isTextValid = false;
                try
                {
                    messageService.ValidateMessageText(messageText);
                    isTextValid = true;
                }
                catch (Exception ex)
                {
                    WriteLn(ex.Message, ConsoleColor.Red);
                }

                if (isTextValid)
                {
                    try
                    {
                        messageService.SendMessage(messageText, user.Id, recipientId);
                        WriteLn("Message successfuly delivered!", ConsoleColor.Green);
                    }
                    catch (Exception ex)
                    {
                        WriteLn($"Sending message failed: {ex.Message}", ConsoleColor.Red);
                    }
                }
            }
        }
        */
    }
}
