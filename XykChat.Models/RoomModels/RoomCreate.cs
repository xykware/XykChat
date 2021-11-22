using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XykChat.Models.RoomModels
{
    public class RoomCreate
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public Guid OwnerID { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
