using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XykChat.Data;

namespace XykChat.Models.MessageModels
{
    public class MessageListItem
    {
        public int ID { get; set; }

        public string Content { get; set; }

        public int ChannelID { get; set; }

        [ForeignKey(nameof(Sender))]
        public Guid SenderID { get; set; }

        public virtual Member Sender { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
