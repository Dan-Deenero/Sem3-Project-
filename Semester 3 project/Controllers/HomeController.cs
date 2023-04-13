using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Semester_3_project.Models;

namespace Semester_3_project.Controllers
{
    public class HomeController : Controller
    {


        OrendeeDBEntities JobEnt = new OrendeeDBEntities();
        Applicant newApp = new Applicant();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FAQS()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult adminLogin()
        {
            ViewBag.Message = "Admin login page";

            return View();
        }
        public ActionResult userLogin()
        {
            ViewBag.Message = "user login page";

            return View();
        }

        [HttpPost]
        public ActionResult addapplicant(Applicant data)
        {
            if (data != null)
            {
                newApp.Fullname = data.Fullname;
                newApp.Email = data.Email;
                newApp.PhoneNo = data.PhoneNo;
                newApp.CV = data.CV;
                newApp.Password = data.Password;
                newApp.Username = data.Username;

                JobEnt.Applicants.Add(newApp);
                return View();
            }
            else
            {
                return Content("Form cannot be empty");
            }
           
        }

        public ActionResult applic_list()
        {
            ViewBag.Message = "applicant list page.";

            return View();
        }

        public ActionResult editQuest()
        {
            ViewBag.Message = "edit question page.";

            return View();
        }

        public ActionResult applicantPage()
        {
            ViewBag.Message = "applicant page.";

            return View();
        }
    }
}