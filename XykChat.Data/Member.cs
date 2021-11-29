using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XykChat.Data
{
    public class Member
    {
        [Key]
        public Guid UserID { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Message> Messages { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
