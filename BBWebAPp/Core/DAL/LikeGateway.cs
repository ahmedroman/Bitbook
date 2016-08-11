using BBWebAPp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BBWebAPp.Core.DAL
{
    public class LikeGateway:CommonGateway
    {
        public int SaveLike(Like like)
        {
            string query = String.Format("INSERT INTO [Like](StatusId, PersonId, PersonName) VALUES({0}, {1}, '{2}')",
                like.StatusId, like.PersonId, like.PersonName);
            command = new SqlCommand(query, conn);
            conn.Open();
            int affectedRow = command.ExecuteNonQuery();
            conn.Close();
            return affectedRow;
        }
        public int DeleteLikeByPerson(Like like)
        {
            string query = String.Format("DELETE FROM [Like] WHERE StatusId={0} AND PersonId={1}",
                like.StatusId, like.PersonId);
            command = new SqlCommand(query, conn);
            conn.Open();
            int affectedRow = command.ExecuteNonQuery();
            conn.Close();
            return affectedRow;
        }
        public Dictionary<int?, int?> GetLikeCountOfStatus()
        {
            Dictionary<int?, int?> likeCountOfStatus = new Dictionary<int?, int?>();
            string query = "SELECT COUNT(*)as LikeCount,StatusId  FROM [Like] GROUP BY StatusId";
            command = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            { 
                while(reader.Read())
                {
                    likeCountOfStatus.Add(Convert.ToInt32(reader["StatusId"]), Convert.ToInt32(reader["LikeCount"]));
                }
            }
            reader.Close();
            conn.Close();
            return likeCountOfStatus;
        }
        public List<Like> GetLikesByPerson(int? personId)
        {
            List<Like> likesByPerson = new List<Like>();
            string query = String.Format("SELECT * FROM [Like] WHERE PersonId={0}", personId);
            command = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Like like = new Like();
                    like.StatusId = Convert.ToInt32(reader["StatusId"]);
                    like.PersonId = Convert.ToInt32(reader["PersonId"]);
                    like.PersonName = reader["PersonName"].ToString();
                    likesByPerson.Add(like);
                }
            }
            reader.Close();
            conn.Close();
            return likesByPerson;
        }

        public List<Like> GetLikeByStatus(int statusId)
        {
            List<Like> likesOfStatus = new List<Like>();
            string query = String.Format("SELECT * FROM [Like] WHERE StatusId={0}", statusId);
            command = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            if(reader.HasRows)
            {
                while (reader.Read())
                {
                    Like like = new Like();
                    like.StatusId = Convert.ToInt32(reader["StatusId"]);
                    like.PersonId = Convert.ToInt32(reader["PersonId"]);
                    like.PersonName = reader["PersonName"].ToString();
                    likesOfStatus.Add(like);
                }
            }
            reader.Close();
            conn.Close();
            return likesOfStatus;
        }
    }
}