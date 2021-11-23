using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XykChat.Data;

namespace XykChat.Models.MemberModels
{
    public class MemberRoomList
    {
        public ICollection<Room> Rooms { get; set; } = new List<Room>();
    }
}
