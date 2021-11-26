﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XykChat.Models.ChannelModels
{
    public class ChannelListItem
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int RoomID { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }
    }
}
