using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BBWebAPp.Core.BLL;
using BBWebAPp.Models;

namespace BBWebAPp.Controllers
{
    public class HomeController : Controller
    {
        StatusManager statusManager = new StatusManager();
        LikeManager likeManager = new LikeManager();
        FriendsManager friendsManager = new FriendsManager();
        ProfilePicManager profilePicManager = new ProfilePicManager();
        public ActionResult Index()
        {
            if (!LoggedIn()) return RedirectToAction("Login", "Account");

            Person loggedInPerson = (Person)Session["LoggedInPerson"];

            ViewBag.Person = new Person();

            ViewBag.LikeCountOfStatus = likeManager.GetLikeCountOfStatus();
            ViewBag.LikesByPerson = likeManager.GetLikesByPerson(loggedInPerson.Id);

            List<Friends> friends = friendsManager.GetFriendsByPersonId(loggedInPerson.Id);
            Friends loggedIn = new Friends();
            loggedIn.FriendId = loggedInPerson.Id;
            friends.Add(loggedIn);
            List<Status> astatus = new List<Status>();
            List<Status> statusList= new List<Status>();
            foreach(var afriend in friends)
            {
                astatus = statusManager.GetStatusByPersonId(afriend.FriendId);
                foreach(var sts in astatus)
                {
                    statusList.Add(sts);              
                }
            }
            List<Status> sortedList = statusList.OrderBy(o => o.Date).ToList();
            sortedList.Reverse();
            //ViewBag.StatusList = statusManager.GetAllStatus();
            ViewBag.StatusList = sortedList;

            ProfilePic newProPic = profilePicManager.GetProfilePicByPrsonId(loggedInPerson.Id);
            ViewBag.ProfilePic = newProPic;

            return View();

        }
        [HttpPost]
        public ActionResult Index(Status status)
        {
            if (!LoggedIn()) return RedirectToAction("Login", "Account");

            Person loggedInPerson = (Person)Session["LoggedInPerson"];
            status.PersonId = loggedInPerson.Id;
            status.PersonName = loggedInPerson.Name;
            status.Date = DateTime.Now;
            int affectedRow = statusManager.SaveStatus(status);
           // ViewBag.StatusList = statusManager.GetAllStatus();
            ViewBag.Person = new Person() ;
            ViewBag.LikeCountOfStatus = likeManager.GetLikeCountOfStatus();
            ViewBag.LikesByPerson = likeManager.GetLikesByPerson(loggedInPerson.Id);

            List<Friends> friends = friendsManager.GetFriendsByPersonId(loggedInPerson.Id);

            List<Status> astatus = new List<Status>();
            List<Status> statusList = new List<Status>();
            foreach (var afriend in friends)
            {
                astatus = statusManager.GetStatusByPersonId(afriend.FriendId);
                foreach (var sts in astatus)
                {
                    statusList.Add(sts);
                }
            }
            List<Status> sortedList = statusList.OrderBy(o => o.Date).ToList();
            sortedList.Reverse();
            //ViewBag.StatusList = statusManager.GetAllStatus();
            //ViewBag.StatusList = statusManager.GetAllStatus();
            ViewBag.StatusList = statusList;

            ProfilePic newProPic = profilePicManager.GetProfilePicByPrsonId(loggedInPerson.Id);
            ViewBag.ProfilePic = newProPic;

            return RedirectToAction("Index");

        }


        private bool LoggedIn()
        {
            return (Session["LoggedInPerson"] == null) ? false : true;
        }
    }
}