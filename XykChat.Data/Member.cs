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
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Guid UserID { get; set; }

        public ICollection<Room> Rooms { get; set; } = new List<Room>();

        public ICollection<Member> Friends { get; set; } = new List<Member>();
    }
}
