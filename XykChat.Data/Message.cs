using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XykChat.Data
{
    public class Message
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Content { get; set; }

        [ForeignKey(nameof(Channel))]
        public int ChannelID { get; set; }

        public virtual Channel Channel { get; set; }

        public Guid SenderID { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
