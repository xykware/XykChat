using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XykChat.Models.RelationshipModels
{
    public class RelationshipAddRoom
    {
        public int ID { get; set; }

        [Required]
        public Guid UserID { get; set; }

        [Required]
        public int? RoomID { get; set; }
    }
}
