using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using XykChat.Data;
using XykChat.Models.ChannelModels;
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

        public IEnumerable<ChannelListItem> GetRoomChannels(int roomID)
        {
            var relationships = _context
                .Relationships
                .Where(e => e.UserID == _userID && e.RoomID == roomID)
                .ToList();

            List<ChannelListItem> channelList = new List<ChannelListItem>();

            foreach (Relationship r in relationships)
            {
                var channels = _context
                    .Channels
                    .Where(e => e.RoomID == r.RoomID)
                    .ToList();

                foreach (Channel c in channels)
                {
                    channelList.Add
                        (
                            new ChannelListItem
                            {
                                ID = c.ID,
                                Name = c.Name,
                                RoomID = c.RoomID,
                                CreatedUtc = c.CreatedUtc
                            }
                        );
                }
            }

            return channelList.ToArray();
        }

        public bool AddRoomChannel(ChannelCreate model, int roomID)
        {
            var room = _context
                .Rooms
                .Where(e => e.OwnerID == _userID && e.ID == roomID)
                .ToList()
                .Single();

            var channel = new Channel
            {
                Name = model.Name,
                RoomID = room.ID,
                CreatedUtc = DateTimeOffset.Now
            };

            _context.Channels.Add(channel);
            return _context.SaveChanges() == 1;
        }

        public bool JoinRoom(RoomJoin model, int roomID)
        {
            var room = _context
                .Rooms
                .Where(e => e.ID == roomID)
                .ToList()
                .Single();

            if(room.Password != model.Password)
            {
                return false;
            }

            var relationshipList = _context
                .Relationships
                .Where(e => e.UserID == _userID && e.RoomID == roomID)
                .ToList();

            if(relationshipList.Count > 0)
            {
                return false;
            }

            var relationship = new Relationship
            {
                UserID = _userID,
                RoomID = room.ID
            };

            _context.Relationships.Add(relationship);

            return _context.SaveChanges() == 1;
        }
    }
}
