using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module19.Final.BLL.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int SenderId { get; set; }
        public int RecipientId { get; set; }

        public Message(
            int id,
            string text,
            int senderId,
            int recipientId)
        {
            Id = id;
            Content = text;
            SenderId = senderId;
            RecipientId = recipientId;
        }
    }
}
