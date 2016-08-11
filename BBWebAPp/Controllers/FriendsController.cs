using BBWebAPp.Core.BLL;
using BBWebAPp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BBWebAPp.Controllers
{
    public class FriendsController : Controller
    {
        FriendsManager friendsManager = new FriendsManager();
        PersonManager personManager = new PersonManager();


        
        public ActionResult AddFriend(Friends friend, string link)
        {
            if (!LoggedIn()) return RedirectToAction("Login", "Account");

            int affectedRow = friendsManager.SendFriendRequest(friend);
            Friends aFriend = new Friends();
            aFriend.PersonId = friend.FriendRequestId;
            aFriend.FriendResponseId = friend.PersonId;
            aFriend.FriendName = friend.FriendName;
            int affectedrowForResponse = friendsManager.SaveFriendResponse(aFriend);
            return RedirectPermanent(link);
            //return RedirectToAction("ShowProfile", "Profile", new { id = friend.FriendRequestId });
        }
        [HttpPost]
        public ActionResult AcceptRequest(Friends friend, string link)
        {
            if (!LoggedIn()) return RedirectToAction("Login", "Account");

            Person loggedInPerson = (Person)Session["LoggedInPerson"];
            friendsManager.AcceptFriendRequest(friend);

            Friends aFriend = new Friends();
            aFriend.PersonId = friend.FriendResponseId;
            aFriend.FriendRequestId = friend.PersonId;
            aFriend.FriendName = loggedInPerson.Name;
            friendsManager.UpdateFriend(aFriend);
            
            return RedirectPermanent(link);

            //return RedirectToAction("ShowProfile", "Profile", new { id = friend.FriendResponseId });
        }
        public ActionResult FriendList(int? id)
        {
            if (!LoggedIn()) return RedirectToAction("Login", "Account");

            Person loggedInPerson = (Person)Session["LoggedInPerson"];

            List<Friends> friendList = friendsManager.GetFriendsByPersonId(id);
            ViewBag.Person = personManager.GetPersonById(id);
            foreach (var friend in friendList)
            {
                Person person = new Person();
                person.Id = friend.FriendId;
                friend.FoundFriend = Found(loggedInPerson, person);
            }
            ViewBag.FriendList = friendList;

            return View();
        }
        public ActionResult ShowRequest(int? id)
        {
            if (!LoggedIn()) return RedirectToAction("Login", "Account");

            Person loggedInPerson = (Person)Session["LoggedInPerson"];
            ViewBag.Person = personManager.GetPersonById(id);

            List<Friends> friendRequests = friendsManager.GetFriendResponsesByPersonId(loggedInPerson.Id);
            foreach (var friend in friendRequests)
            {
                Person person = new Person();
                person.Id = friend.FriendResponseId;
                friend.FoundFriend = Found(loggedInPerson, person);
            }
            ViewBag.FriendList = friendRequests;

            return View();
        }

        public ActionResult SentRequests(int? id)
        {
            if (!LoggedIn()) return RedirectToAction("Login", "Account");

            Person loggedInPerson = (Person)Session["LoggedInPerson"];
            ViewBag.Person = personManager.GetPersonById(id);

            List<Friends> friendRequests = friendsManager.GetFriendRequestsByPersonId(loggedInPerson.Id);
            foreach (var friend in friendRequests)
            {
                Person person = new Person();
                person.Id = friend.FriendRequestId;
                friend.FoundFriend = Found(loggedInPerson, person);
            }
            ViewBag.FriendList = friendRequests;

            return View("ShowRequest");
        }

        public ActionResult SearchPerson(string Name)
        {
            if (!LoggedIn()) return RedirectToAction("Login", "Account");
            Person loggedInPerson = (Person)Session["LoggedInPerson"];
            ViewBag.Person = personManager.GetPersonById(loggedInPerson.Id);

            List<Person> personList = personManager.GetPersonByName(Name);
            List<Friends> friendRequests = new List<Friends>();
            //ViewBag.PersonList = personList;
            foreach (var aPerson in personList)
            {
                Friends friend = new Friends();
                friend.PersonId = aPerson.Id;
                friend.FriendName = aPerson.Name;
                friend.FoundFriend = Found(loggedInPerson, aPerson);
                friendRequests.Add(friend);
            }
            ViewBag.FriendList = friendRequests;

            return View();
        }
        [HttpPost]
        public ActionResult IgnoreRequest(Friends friend, string link)
        {
            if (!LoggedIn()) return RedirectToAction("Login", "Account");

            friendsManager.IgnoreFriendRequest(friend);
            return RedirectPermanent(link);
        }
        [HttpPost]
        public ActionResult CancelRequest(Friends friend, string link)
        {
            if (!LoggedIn()) return RedirectToAction("Login", "Account");

            friendsManager.CancelRequest(friend);
            return RedirectPermanent(link);
        }

        private string Found(Person loggedInPerson, Person person)
        {
            string found = "";
            List<Friends> friends = friendsManager.GetFriendsByPersonId(loggedInPerson.Id);
            List<Friends> friendResponses = friendsManager.GetFriendResponsesByPersonId(loggedInPerson.Id);
            List<Friends> friendRequests = friendsManager.GetFriendRequestsByPersonId(loggedInPerson.Id);
            if (loggedInPerson.Id != person.Id)
            {
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
            }
            return found;
        }
        private bool LoggedIn()
        {
            return (Session["LoggedInPerson"] == null) ? false : true;
        }

    }
}