using BBWebAPp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BBWebAPp.Core.DAL
{
    public class FriendsGateway:CommonGateway
    {
        public int SendFriendRequest(Friends friend)
        {
            string query = String.Format("INSERT INTO Friends(PersonId, FriendRequestId, FriendName) VALUES({0}, {1}, '{2}')",
                friend.PersonId, friend.FriendRequestId, friend.FriendName);
            command = new SqlCommand(query, conn);
            conn.Open();
            int affectedRow = command.ExecuteNonQuery();
            conn.Close();
            return affectedRow;
        }
        public int SaveFriendResponse(Friends friend)
        {
            string query = String.Format("INSERT INTO Friends(PersonId, FriendResponseId, FriendName) VALUES({0}, {1}, '{2}')",
                friend.PersonId, friend.FriendResponseId, friend.FriendName);
            command = new SqlCommand(query, conn);
            conn.Open();
            int affectedRow = command.ExecuteNonQuery();
            conn.Close();
            return affectedRow;
        }
        public int AcceptFriendRequest(Friends friend)
        {
            string query = String.Format("UPDATE Friends SET FriendResponseId=NULL, FriendName='{0}', FriendId={1} WHERE PersonId={2} AND FriendResponseId={3}",
               friend.FriendName, friend.FriendResponseId, friend.PersonId, friend.FriendResponseId);
            command = new SqlCommand(query, conn);
            conn.Open();
            int affectedRow = command.ExecuteNonQuery();
            conn.Close();
            
            return affectedRow;

        }
        public int IgnoreFriendRequest(Friends friend)
        {
            string query = String.Format("DELETE FROM Friends WHERE PersonId={0} AND FriendResponseId={1}",
               friend.PersonId, friend.FriendResponseId);
            command = new SqlCommand(query, conn);
            conn.Open();
            int affectedRow = command.ExecuteNonQuery();
            conn.Close();

            DeleteRequest(friend);

            return affectedRow;

        }
        private int DeleteRequest(Friends friend)
        {
            string query = String.Format("DELETE FROM Friends WHERE PersonId={0} AND FriendRequestId={1}",
               friend.FriendResponseId, friend.PersonId);
            command = new SqlCommand(query, conn);
            conn.Open();
            int affectedRow = command.ExecuteNonQuery();
            conn.Close();

            return affectedRow;
        }
        public int CancelRequest(Friends friend)
        {
            string query = String.Format("DELETE FROM Friends WHERE PersonId={0} AND FriendRequestId={1}",
               friend.PersonId, friend.FriendRequestId);
            command = new SqlCommand(query, conn);
            conn.Open();
            int affectedRow = command.ExecuteNonQuery();
            conn.Close();

            Friends aFriend = new Friends();
            aFriend.PersonId = friend.FriendRequestId;
            aFriend.FriendResponseId = friend.PersonId;
            IgnoreFriendRequest(aFriend);
            return affectedRow;
        }
        public int UpdateFriend(Friends friend) 
        {
            string query = String.Format("UPDATE Friends SET FriendRequestId=NULL, FriendName='{0}', FriendId={1} WHERE PersonId={2} AND FriendRequestId={3}",
               friend.FriendName, friend.FriendRequestId, friend.PersonId, friend.FriendRequestId);
            command = new SqlCommand(query, conn);
            conn.Open();
            int affectedRow = command.ExecuteNonQuery();
            conn.Close();
            return affectedRow;
        }
        public List<Friends> GetFriendsByPersonId(int? personId)
        {
            List<Friends> friendList = new List<Friends>();
            string query = String.Format("SELECT * FROM Friends WHERE  PersonId={0} AND FriendId IS NOT NULL",
                personId);
            command = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            { 
                while(reader.Read())
                {
                    Friends friends = new Friends();
                    friends.PersonId = Convert.ToInt32(reader["PersonId"]);
                    friends.FriendId = Convert.ToInt32(reader["FriendId"]);
                    friends.FriendName = reader["FriendName"].ToString();
                    friendList.Add(friends); 
                }
            }
            reader.Close();
            conn.Close();
            return friendList;
        }
        public List<Friends> GetFriendRequestsByPersonId(int? personId)
        {
            List<Friends> friendRequestList = new List<Friends>();
            string query = String.Format("SELECT * FROM Friends WHERE  PersonId={0} AND FriendRequestId IS NOT NULL",
                personId);
            command = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Friends friends = new Friends();
                    friends.PersonId = Convert.ToInt32(reader["PersonId"]);
                    friends.FriendRequestId = Convert.ToInt32(reader["FriendRequestId"]);
                    friends.FriendName = reader["FriendName"].ToString();
                    friendRequestList.Add(friends);
                }
            }
            reader.Close();
            conn.Close();
            return friendRequestList;
        }
        public List<Friends> GetFriendResponsesByPersonId(int? personId)
        {
            List<Friends> friendResponseIdList = new List<Friends>();
            string query = String.Format("SELECT * FROM Friends WHERE  PersonId={0} AND FriendResponseId IS NOT NULL",
                personId);
            command = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Friends friends = new Friends();
                    friends.PersonId = Convert.ToInt32(reader["PersonId"]);
                    friends.FriendResponseId = Convert.ToInt32(reader["FriendResponseId"]);
                    friends.FriendName = reader["FriendName"].ToString();
                    friendResponseIdList.Add(friends);
                }
            }
            reader.Close();
            conn.Close();
            return friendResponseIdList;
        }


    }
}