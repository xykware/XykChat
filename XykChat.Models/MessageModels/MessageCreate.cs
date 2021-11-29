using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XykChat.Models.MessageModels
{
    public class MessageCreate
    {
        public int ID { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
