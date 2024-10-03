﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TweetPostingService.Core.Entities
{
    public class Tweet
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; }
    }
}
