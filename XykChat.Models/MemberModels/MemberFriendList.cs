using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XykChat.Data;

namespace XykChat.Models.MemberModels
{
    public class MemberFriendList
    {
        public ICollection<Member> Friends { get; set; } = new List<Member>();
    }
}
