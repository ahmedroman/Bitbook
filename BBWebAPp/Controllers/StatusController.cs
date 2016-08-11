using BBWebAPp.Core.BLL;
using BBWebAPp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BBWebAPp.Controllers
{
    public class StatusController : Controller
    {
        LikeManager likeManager = new LikeManager();
        CommentManager commentManager = new CommentManager();
        StatusManager statusManager = new StatusManager();
        public ActionResult SaveLike(Like like, string link)
        {
            int affectedRow = likeManager.SaveLike(like);
            if (affectedRow > 0) return RedirectPermanent(link);
            else return RedirectToAction("Index", "Home");

        }
        public ActionResult DeleteLike(Like like, string link)
        {
            int affectedRow = likeManager.DeleteLikeByPerson(like);
            if (affectedRow > 0) return RedirectPermanent(link);
            else return RedirectToAction("Index", "Home");
        }
        public ActionResult SaveComment(string link)
        {
            return RedirectPermanent(link);
        }
        [HttpPost]
        public ActionResult SaveComment(Comment comment, string link)
        {
            int affectedRow = 0;
            if (comment.CommentDesc != null)
            {
                comment.Date = DateTime.Now;
                affectedRow = commentManager.SaveComment(comment);
            }
            if (affectedRow > 0)
            {
                TempData["message"] = "Comment Posted";
                return RedirectPermanent(link);
            }
            else
            {
                TempData["message"] = "Failed to Post";
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult GetComment()
        {
            return RedirectToAction("Index", "Home");

            //return RedirectPermanent(link);
        }
        [HttpPost]
        public ActionResult GetComment(int StatusId)
        {
            List<Comment> commentsOfStatus = commentManager.GetCommentsByStatus(StatusId);
            ViewBag.CommentsOfStatus = commentsOfStatus;
            //TempData["CommentsOfStatus"] = commentsOfStatus;
            return PartialView("_Comment");
            //return RedirectPermanent(link);

        }
        public ActionResult DeletePost(string link)
        {
            return RedirectPermanent(link);

        }
        [HttpPost]
        public ActionResult DeletePost(int? id, string link)
        {

            int affecctedRow = statusManager.DeleteStatus(id);
            return RedirectPermanent(link);

        }
    }
}