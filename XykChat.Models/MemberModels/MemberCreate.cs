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
        [Required]
        public string Name { get; set; }

        [Required]
        public Guid UserID { get; set; }
    }
}
