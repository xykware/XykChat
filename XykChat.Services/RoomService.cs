using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using XykChat.Data;
using XykChat.Models.RoomModels;

namespace XykChat.Services
{
    public class RoomService
    {
        private readonly Guid _userID;

        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public RoomService(Guid userID)
        {
            _userID = userID;
        }

        public bool Create(RoomCreate model)
        {
            Room entity = new Room
            {
                Name = model.Name,
                Description = model.Description,
                OwnerID = _userID,
                CreatedUtc = DateTimeOffset.Now
            };

            _context.Rooms.Add(entity);

            return _context.SaveChanges() == 1;
        }

        public IEnumerable<RoomListItem> GetRooms()
        {
            var user = _context
                .Members
                .Where(e => e.UserID == _userID);

            var member = new Member();

            foreach(Member m in user)
            {
                member = m;
            }

            return member
                .Rooms
                .Select
                (
                    e =>
                        new RoomListItem
                        {
                            ID = e.ID,
                            Name = e.Name,
                            Description = e.Description,
                            CreatedUtc = e.CreatedUtc
                        }
                )
                .ToArray();
        }
    }
}
