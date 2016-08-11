using BBWebAPp.Core.DAL;
using BBWebAPp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BBWebAPp.Core.BLL
{
    public class LikeManager
    {
        LikeGateway likeGateway = new LikeGateway();

        public int SaveLike(Like like)
        {
            return likeGateway.SaveLike(like);

        }
        public int DeleteLikeByPerson(Like like) 
        {
            return likeGateway.DeleteLikeByPerson(like);
        }
        public List<Like> GetLikesByPerson(int? personId)
        {
            return likeGateway.GetLikesByPerson(personId);
        }
        public List<Like> GetLikeByStatus(int statusId)
        {
            return likeGateway.GetLikeByStatus(statusId);
        }
        public Dictionary<int?, int?> GetLikeCountOfStatus()
        {
            return likeGateway.GetLikeCountOfStatus();
        }
        
    }
}