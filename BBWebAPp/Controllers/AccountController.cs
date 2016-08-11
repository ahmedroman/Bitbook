using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BBWebAPp.Core.BLL;
using BBWebAPp.Models;

namespace BBWebAPp.Controllers
{
    public class AccountController : Controller
    {
        PersonManager personManager = new PersonManager();
        ProfilePicManager profilePicManager = new ProfilePicManager();
        CoverPicManager coverPicManager = new CoverPicManager();
        public ActionResult Login()
        {
            Session["LoggedInPerson"] = null;
            return View();
        }
        [HttpPost]
        public ActionResult Login(Person person)
        {
            Session["LoggedInPerson"] = null;
            Person existingPerson = personManager.SuccessfullLogin(person);
            if (existingPerson != null)
            {
                Session["LoggedInPerson"] = existingPerson;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Message = "Invalid Email/Password";
                return View();
            }
        }
        public ActionResult Registration()
        {
            ViewBag.Message = "";
            return View();
        }
        [HttpPost]
        public ActionResult Registration(Person person)
        {
            int affectedRow = 0;
            if (!personManager.IsEmailExist(person.Email))
            {
                affectedRow = personManager.SavePerson(person);
                ProfilePic profilePic = profilePicManager.GetProfilePicById(1);
                profilePic.Personid = affectedRow;
                profilePicManager.SaveProfilePic(profilePic);

                CoverPic coverPic = coverPicManager.GetCoverPicById(1);
                coverPic.Personid = affectedRow;
                coverPicManager.SaveCoverPic(coverPic);
            }
            else
            {
                ViewBag.Message = "Email must be unique.";
                return View();
            }
            if (affectedRow > 0)
            {
                ViewBag.Message = "Registration Successfull.";
            }
            else
            {
                ViewBag.Message = "Registration Failed.";
            }

            return View();
        }
	}
}