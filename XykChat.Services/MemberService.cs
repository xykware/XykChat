using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XykChat.Data;
using XykChat.Models.MemberModels;
using XykChat.Models.RoomModels;

namespace XykChat.Services
{
    public class MemberService
    {
        private readonly Guid _userID;

        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public MemberService(Guid userID)
        {
            _userID = userID;
        }

        public bool Create(MemberCreate model)
        {
            Member entity = new Member
            {
                Name = model.Name,
                UserID = _userID,
                CreatedUtc = DateTimeOffset.Now
            };

            var user = _context
                .Members
                .Where(e => e.UserID == _userID)
                .ToList();

            int count = 0;

            foreach (Member m in user)
            {
                count++;
            }

            if (count == 0)
            {
                _context.Members.Add(entity);
            }

            return _context.SaveChanges() == 1;
        }
    }
}
