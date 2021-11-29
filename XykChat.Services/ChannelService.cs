using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XykChat.Data;
using XykChat.Models.MessageModels;

namespace XykChat.Services
{
    public class ChannelService
    {
        private readonly Guid _userID;

        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public ChannelService(Guid userID)
        {
            _userID = userID;
        }

        public IEnumerable<MessageListItem> GetChannelMessages(int channelID)
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

            List<MessageListItem> messageList = new List<MessageListItem>();

            if (relationships.Count == 0)
            {
                return messageList.ToArray();
            }

            foreach (Relationship r in relationships)
            {
                var messages = _context
                    .Messages
                    .Where(e => e.ChannelID == channelID)
                    .ToList();

                foreach (Message m in messages)
                {
                    messageList.Add
                        (
                            new MessageListItem
                            {
                                ID = m.ID,
                                Content = m.Content,
                                ChannelID = m.ChannelID,
                                SenderID = m.SenderID,
                                Sender = m.Sender,
                                CreatedUtc = m.CreatedUtc,
                                ModifiedUtc = m.ModifiedUtc
                            }
                        );
                }
            }

            return messageList.ToArray();
        }
    }
}
