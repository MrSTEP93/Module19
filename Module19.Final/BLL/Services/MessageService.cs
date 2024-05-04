using Module19.Final.BLL.Exceptions;
using Module19.Final.BLL.Models;
using Module19.Final.DAL.Entities;
using Module19.Final.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module19.Final.BLL.Services
{
    public class MessageService
    {
        IMessageRepository messageRepository;

        public MessageService()
        {
            messageRepository = new MessageRepository();
        }

        public void SendMessage(MessageSendingData messageSendingData)
        {
            Validator.ValidateAddress(messageSendingData.RecipientEmail);
            Validator.ValidateStringMaxSize(messageSendingData.Content, "Message content", 5000);

            var userService = new UserService();
            var foundUser = userService.FindByEmail(messageSendingData.RecipientEmail) ?? throw new UserNotFoundException();

            var messageEntity = new MessageEntity()
            {
                content = messageSendingData.Content,
                sender_id = messageSendingData.SenderId,
                recipient_id = foundUser.Id
            };

            if (messageRepository.Create(messageEntity) == 0)
            {
                throw new Exception();
            }
        }

        public IEnumerable<Message> GetIncomingMessagesByUserId(int recipientId)
        {
            var messages = new List<Message>();
            messages = messageRepository.FindByRecipientId(recipientId).
                Select(mes => new Message(mes.id, mes.content, mes.sender_id, recipientId)).ToList();

            return messages;
        }

        public IEnumerable<Message> GetOutgoingMessagesByUserId(int senderId)
        {
            return messageRepository.FindBySenderId(senderId).
                Select(mes => new Message(mes.id, mes.content, senderId, mes.recipient_id)).ToList();
        }

        private Message ConstructMessageModel(MessageEntity messageEntity)
        {
            return new Message(
                messageEntity.id,
                messageEntity.content,
                messageEntity.sender_id,
                messageEntity.recipient_id
                );
        }
    }
}
