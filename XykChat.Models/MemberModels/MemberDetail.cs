using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XykChat.Data;

namespace XykChat.Models.MemberModels
{
    public class MemberDetail
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public Guid UserID { get; set; }

        public ICollection<Room> Rooms { get; set; }

        public ICollection<Member> Friends { get; set; }
    }
}
