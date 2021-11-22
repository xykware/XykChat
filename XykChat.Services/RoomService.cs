using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public bool CreateRoom(RoomCreate model)
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
    }
}
