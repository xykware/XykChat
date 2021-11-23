using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XykChat.Models.MemberModels
{
    public class MemberCreate
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Guid UserID { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
