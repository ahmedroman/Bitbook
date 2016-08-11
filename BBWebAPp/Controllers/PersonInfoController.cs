using BBWebAPp.Core.BLL;
using BBWebAPp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BBWebAPp.Controllers
{
    public class PersonInfoController : Controller
    {
        PersonManager personManager = new PersonManager();

        public ActionResult SearchPerson(Person person)
        {
            if (!LoggedIn()) return RedirectToAction("Login", "Account");
            Person loggedInPerson = (Person)Session["LoggedInPerson"];
            ViewBag.Person = personManager.GetPersonById(loggedInPerson.Id);

            List<Person> personList = personManager.GetPersonByName(person.Name);
            ViewBag.PersonList = personList;

            return View("ShowRequest", "Friends");
        }
        public ActionResult ShowInfo(int? id)
        {
            if (!LoggedIn()) return RedirectToAction("Login", "Account");
            if (id == null) return RedirectToAction("Index", "Home");
            ViewBag.Person = personManager.GetPersonById(id);
            return View();
        }
        public ActionResult UpdateInfo(int? id)
        {
            if (!LoggedIn()) return RedirectToAction("Login", "Account");
            if (id == null) return RedirectToAction("Index", "Home");
            ViewBag.Person = personManager.GetPersonById(id);

            //Person loggedInPerson = (Person)Session["LoggedInPerson"];
            //if(id != loggedInPerson.Id) return RedirectToAction("ShowInfo");

            return View();
        }
        [HttpPost]
        public ActionResult UpdateInfo(Person person, int? id)
        {
            if (!LoggedIn()) return RedirectToAction("Login", "Account");
            if (id == null) return RedirectToAction("Index", "Home");
            ViewBag.Person = personManager.GetPersonById(id);

            //Person loggedInPerson = (Person)Session["LoggedInPerson"];
            //if(id != loggedInPerson.Id) return RedirectToAction("ShowInfo");

            int affectedRow = personManager.UpdatePerson(person);
            if (affectedRow > 0) return RedirectToAction("ShowInfo", new {id=id });
            return View();
        }


        private bool LoggedIn()
        {
            return (Session["LoggedInPerson"] == null) ? false : true;
        }

	}
}