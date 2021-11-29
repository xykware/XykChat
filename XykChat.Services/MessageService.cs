using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XykChat.Data;
using XykChat.Models.MessageModels;

namespace XykChat.Services
{
    public class MessageService
    {
        private readonly Guid _userID;

        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public MessageService(Guid userID)
        {
            _userID = userID;
        }

        public bool SendChannelMessage(MessageCreate model, int channelID)
        {
            var channel = _context
                .Channels
                .Where(e => e.ID == channelID)
                .ToList()
                .Single();

            var relationships = _context
                .Relationships
                .Where(e => e.UserID == _userID && e.RoomID == channel.RoomID)
                .ToList();

            if (relationships.Count == 0)
            {
                return false;
            }

            var message = new Message
            {
                Content = model.Content,
                ChannelID = channelID,
                SenderID = _userID,
                CreatedUtc = DateTimeOffset.Now
            };

            _context.Messages.Add(message);

            return _context.SaveChanges() == 1;
        }
    }
}
