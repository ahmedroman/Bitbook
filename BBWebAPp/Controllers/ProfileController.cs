using BBWebAPp.Core.BLL;
using BBWebAPp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BBWebAPp.Controllers
{
    public class ProfileController : Controller
    {
        StatusManager statusManager = new StatusManager();
        LikeManager likeManager = new LikeManager();

        PersonManager personManeger = new PersonManager();
        FriendsManager friendsManager = new FriendsManager();
        ProfilePicManager profilePicManager = new ProfilePicManager();
        CoverPicManager coverPicManager = new CoverPicManager();

        public ActionResult ShowProfile(int? id)
        {
            if (!LoggedIn()) return RedirectToAction("Login", "Account");
            if (id == null) return RedirectToAction("Index", "Home");

            Person loggedInPerson = (Person)Session["LoggedInPerson"];

            Person person = personManeger.GetPersonById(id);
            ViewBag.Person = person;

            ViewBag.StatusList = statusManager.GetStatusByPersonId(id);

            string found = Found(loggedInPerson, person);
            ViewBag.Found = found;

            ProfilePic newProPic = profilePicManager.GetProfilePicByPrsonId(person.Id);
            ViewBag.ProfilePic = newProPic;

            CoverPic newCoverPic = coverPicManager.GetCoverPicByPrsonId(person.Id);
            ViewBag.CoverPic = newCoverPic;

            ViewBag.LikeCountOfStatus = likeManager.GetLikeCountOfStatus();
            ViewBag.LikesByPerson = likeManager.GetLikesByPerson(loggedInPerson.Id);
            ViewBag.Found = Found(loggedInPerson, person);

            return View();

        }
        [HttpPost]
        public ActionResult ShowProfile(int? id, Status status, HttpPostedFileBase profilePic, HttpPostedFileBase coverPic)
        {
            if (!LoggedIn()) return RedirectToAction("Login", "Account");
            if (id == null) return RedirectToAction("Index", "Home");

            Person loggedInPerson = (Person)Session["LoggedInPerson"];

            Person person = personManeger.GetPersonById(id);
            ViewBag.Person = person;


            string found = Found(loggedInPerson, person);
            ViewBag.Found = found;

            status.PersonId = loggedInPerson.Id;
            status.PersonName = loggedInPerson.Name;
            status.Date = DateTime.Now;
            int affectedRow = statusManager.SaveStatus(status);
            ViewBag.StatusList = statusManager.GetStatusByPersonId(id);

            //ProfilePic Update
            if (profilePic != null)
            {
                ProfilePic proPic = new ProfilePic();
                proPic.Caption = Path.GetFileName(profilePic.FileName);
                proPic.Pic = profilePicManager.FileToByteArray(profilePic);
                proPic.Personid = loggedInPerson.Id;
                int proPicId = profilePicManager.UpdateProfilePic(proPic);
            }
            else if(coverPic != null)
            {
                //CoverPic Update
                CoverPic covPic = new CoverPic();
                covPic.Caption = Path.GetFileName(coverPic.FileName);
                covPic.Pic = coverPicManager.FileToByteArray(coverPic);
                covPic.Personid = loggedInPerson.Id;
                int coverPicId = coverPicManager.UpdateCoverPic(covPic);
            }
            
            ProfilePic newProPic = profilePicManager.GetProfilePicByPrsonId(person.Id);
            ViewBag.ProfilePic = newProPic;

            CoverPic newCoverPic = coverPicManager.GetCoverPicByPrsonId(person.Id);
            ViewBag.CoverPic = newCoverPic;
            ViewBag.LikeCountOfStatus = likeManager.GetLikeCountOfStatus();
            ViewBag.LikesByPerson = likeManager.GetLikesByPerson(loggedInPerson.Id);

            ViewBag.Found = Found(loggedInPerson, person);

            //return View();
            return RedirectToAction("ShowProfile");

        }

        private string Found(Person loggedInPerson, Person person)
        {
            string found = "";
            List<Friends> friends = friendsManager.GetFriendsByPersonId(loggedInPerson.Id);
            List<Friends> friendResponses = friendsManager.GetFriendResponsesByPersonId(loggedInPerson.Id);
            List<Friends> friendRequests = friendsManager.GetFriendRequestsByPersonId(loggedInPerson.Id);
            if (friends.Count > 0)
            {
                foreach (Friends friend in friends)
                {
                    if (person.Id == friend.FriendId)
                    {
                        found = "foundFriend";
                        break;
                    }
                }
            }
            if (friendResponses.Count > 0)
            {
                foreach (Friends friend in friendResponses)
                {
                    if (person.Id == friend.FriendResponseId)
                    {
                        found = "foundFriendResponse";
                        break;
                    }
                }
            }
            if (friendRequests.Count > 0)
            {
                foreach (Friends friend in friendRequests)
                {
                    if (person.Id == friend.FriendRequestId)
                    {
                        found = "foundFriendRequest";
                        break;
                    }
                }
            }
            return found;
        }


        private bool LoggedIn()
        {
            return (Session["LoggedInPerson"] == null) ? false : true;
        }

    }
}