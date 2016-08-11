using BBWebAPp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BBWebAPp.Core.DAL
{
    public class CommentGateway:CommonGateway
    {
        public int SaveComment(Comment comment)
        {
            string query = String.Format("INSERT INTO Comment(CommentDesc,StatusId,PersonId,PersonName,[Date]) VALUES('{0}',{1},{2},'{3}','{4}')",
                comment.CommentDesc, comment.StatusId, comment.PersonId, comment.PersonName, comment.Date);
            command = new SqlCommand(query, conn);
            conn.Open();
            int affectedrow = command.ExecuteNonQuery();
            conn.Close();
            return affectedrow;
        }
        public List<Comment> GetCommentsByStatus(int statusId)
        {
            List<Comment> commentsOfStatus = new List<Comment>();
            string query = String.Format("SELECT * FROM Comment WHERE StatusId={0}", statusId);
            command = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            { 
                while(reader.Read())
                {
                    Comment comment = new Comment();
                    comment.CommentId = Convert.ToInt32(reader["CommentId"]);
                    comment.CommentDesc = reader["CommentDesc"].ToString();
                    comment.StatusId = Convert.ToInt32(reader["StatusId"]);
                    comment.PersonId = Convert.ToInt32(reader["PersonId"]);
                    comment.PersonName = reader["PersonName"].ToString();
                    comment.Date = Convert.ToDateTime(reader["Date"]);
                    commentsOfStatus.Add(comment);
                }
            }
            reader.Close();
            conn.Close();
            return commentsOfStatus;
        }
    }
}