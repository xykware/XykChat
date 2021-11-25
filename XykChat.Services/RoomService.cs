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
            var room = new Room
            {
                Name = model.Name,
                Description = model.Description,
                OwnerID = _userID,
                CreatedUtc = DateTimeOffset.Now
            };

            _context.Rooms.Add(room);
            _context.SaveChanges();

            var roomResult = _context
                .Rooms
                .Where(e => e.OwnerID == _userID)
                .ToList()
                .Last();

            var relationship = new Relationship
            {
                UserID = _userID,
                RoomID = roomResult.ID
            };

            _context.Relationships.Add(relationship);

            return _context.SaveChanges() == 1;
        }

        public IEnumerable<RoomListItem> GetRooms()
        {
            var relationships = _context
                .Relationships
                .Where(e => e.UserID == _userID && e.RoomID != null)
                .ToList();

            List<RoomListItem> roomList = new List<RoomListItem>(); 

            foreach(Relationship r in relationships)
            {
                var room = _context
                    .Rooms
                    .Where(e => e.ID == r.RoomID)
                    .ToList()
                    .Single();

                roomList.Add
                    (
                        new RoomListItem
                        {
                            ID = room.ID,
                            Name = room.Name,
                            Description = room.Description,
                            CreatedUtc = room.CreatedUtc
                        }
                    );
            }

            return roomList.ToArray();
        }
    }
}
