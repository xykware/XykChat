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

        public IEnumerable<MemberRoomList> GetRooms()
        {
            return _context
                    .Members
                    .Where(e => e.UserID == _userID)
                    .Select
                    (
                        e =>
                            new MemberRoomList
                            {
                                Rooms = e.Rooms
                            }
                    )
                    .ToArray();
        }

        public IEnumerable<MemberFriendList> GetFriends()
        {
            return _context
                    .Members
                    .Where(e => e.UserID == _userID)
                    .Select
                    (
                        e =>
                            new MemberFriendList
                            {
                                Friends = e.Friends
                            }
                    )
                    .ToArray();
        }

        public bool AddRoom(int id)
        {
            var room = _context
                .Rooms
                .Find(id);

            var user = _context
                .Members
                .Where(e => e.UserID == _userID)
                .ToList();

            foreach(Member m in user)
            {
                m.Rooms.Add(room);
            }

            return _context.SaveChanges() == 1;
        }

        public bool AddFriend(int id)
        {
            var friend = _context
                .Members
                .Find(id);

            var user = _context
                .Members
                .Where(e => e.UserID == _userID)
                .ToList();

            foreach (Member m in user)
            {
                m.Friends.Add(friend);
            }

            return _context.SaveChanges() == 1;
        }

        public bool RemoveRoom(int id)
        {
            var room = _context
                .Rooms
                .Find(id);

            var user = _context
                .Members
                .Where(e => e.UserID == _userID)
                .ToList();

            foreach (Member m in user)
            {
                m.Rooms.Remove(room);
            }

            return _context.SaveChanges() == 1;
        }

        public bool RemoveFriend(int id)
        {
            var friend = _context
                .Members
                .Find(id);

            var user = _context
                .Members
                .Where(e => e.UserID == _userID)
                .ToList();

            foreach (Member m in user)
            {
                m.Friends.Remove(friend);
            }

            return _context.SaveChanges() == 1;
        }
    }
}
