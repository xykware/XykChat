using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XykChat.Data
{
    public class Channel
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [ForeignKey(nameof(Room))]
        public int RoomID { get; set; }

        public virtual Room Room { get; set; }

        public virtual ICollection<Message> Messages { get; set; } = new List<Message>();

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
