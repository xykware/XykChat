using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XykChat.Data;

namespace XykChat.Models.RoomModels
{
    public class RoomDetail
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Guid OwnerID { get; set; }

        public virtual ICollection<Channel> Channels { get; set; } = new List<Channel>();

        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
