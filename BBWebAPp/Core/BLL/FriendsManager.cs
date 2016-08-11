using BBWebAPp.Core.DAL;
using BBWebAPp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BBWebAPp.Core.BLL
{
    public class FriendsManager
    {
        FriendsGateway friendsGateway = new FriendsGateway();
        public int SendFriendRequest(Friends friend)
        {
            return friendsGateway.SendFriendRequest(friend);
        }
        public int SaveFriendResponse(Friends friend)
        {
            return friendsGateway.SaveFriendResponse(friend);
        }
        public int AcceptFriendRequest(Friends friend)
        {
            return friendsGateway.AcceptFriendRequest(friend);
        }
        public int IgnoreFriendRequest(Friends friend)
        {
            return friendsGateway.IgnoreFriendRequest(friend);
        }
        public int CancelRequest(Friends friend)
        {
            return friendsGateway.CancelRequest(friend);
        }
        public int UpdateFriend(Friends friend)
        {
            return friendsGateway.UpdateFriend(friend);
        }
        public List<Friends> GetFriendsByPersonId(int? personId)
        {
            return friendsGateway.GetFriendsByPersonId(personId);
        }
        public List<Friends> GetFriendRequestsByPersonId(int? personId)
        {
            return friendsGateway.GetFriendRequestsByPersonId(personId);
        }
        public List<Friends> GetFriendResponsesByPersonId(int? personId)
        {
            return friendsGateway.GetFriendResponsesByPersonId(personId);
        }
    }
}