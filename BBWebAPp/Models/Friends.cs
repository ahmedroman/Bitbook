using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BBWebAPp.Models
{
    public class Friends
    {
        public int? PersonId { get; set; }
        public int? FriendId { get; set; }
        public int? FriendRequestId { get; set; }
        public int? FriendResponseId { get; set; }
        public string FriendName { get; set; }
        public string FoundFriend { get; set; }
    }
}