using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XykChat.Data;
using XykChat.Models.MemberModels;

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
                UserID = _userID
            };

            _context.Members.Add(entity);

            return _context.SaveChanges() == 1;
        }

        public ICollection<Room> GetRooms()
        {
            return (ICollection<Room>)_context
                    .Members
                    .Where(e => e.UserID == _userID)
                    .Select
                    (
                        e =>
                        e.Rooms
                    );
        }

        public ICollection<Member> GetFriends()
        {
            return (ICollection<Member>)_context
                    .Members
                    .Where(e => e.UserID == _userID)
                    .Select
                    (
                        e =>
                        e.Friends
                    );
        }

        public bool AddRoom(int id)
        {
            var room = _context
                .Rooms
                .Find(id);

            var member = _context
                .Members
                .Where(e => e.UserID == _userID)
                .ToList();

            foreach(Member m in member)
            {
                m.Rooms.Add(room);
            }

            return _context.SaveChanges() == 1;
        }
    }
}
