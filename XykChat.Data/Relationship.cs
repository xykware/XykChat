using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XykChat.Data
{
    public class Relationship
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public Guid UserID { get; set; }

        public int? RoomID { get; set; }

        public int? FriendID { get; set; }
    }
}
