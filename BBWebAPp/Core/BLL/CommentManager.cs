using BBWebAPp.Core.DAL;
using BBWebAPp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BBWebAPp.Core.BLL
{
    public class CommentManager
    {
        CommentGateway commentGateway = new CommentGateway();
        public int SaveComment(Comment comment)
        {
            return commentGateway.SaveComment(comment);
        }
        public List<Comment> GetCommentsByStatus(int statusId)
        {
            return commentGateway.GetCommentsByStatus(statusId);
        }
    }
}