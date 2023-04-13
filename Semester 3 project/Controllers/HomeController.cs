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
        Admin newAdmin = new Admin();
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

        
        public ActionResult adminLogin(Admin data)
        {
            if (data != null && !string.IsNullOrEmpty(data.ad_name) && !string.IsNullOrEmpty(data.ad_pass))
            {
                var admin = JobEnt.Admins.FirstOrDefault(a => a.ad_name == data.ad_name && a.ad_pass == data.ad_pass);
                if (admin != null)
                {
                    // Login successful, redirect to admin panel
                    return RedirectToAction("addapplicant");
                }
                else
                {
                    // Login failed, display error message
                    ViewBag.ErrorMessage = "Invalid username or password";
                    return View();
                }
            }
            else
            {
                // Form data missing, display error message
                ViewBag.ErrorMessage = "Form cannot be empty";
                return View();
            }
        }


        [HttpPost]
        public ActionResult userLogin(Applicant data)
        {
            if (data != null && !string.IsNullOrEmpty(data.Username) && !string.IsNullOrEmpty(data.Password))
            {
                var appl = JobEnt.Applicants.FirstOrDefault(a => a.Username == data.Username && a.Password == data.Password);
                if (appl != null)
                {
                    // Login successful, redirect to admin panel
                    return RedirectToAction("applicantPage");
                }
                else
                {
                    // Login failed, display error message
                    ViewBag.ErrorMessage = "Invalid username or password";
                    return View();
                }
            }
            else
            {
                // Form data missing, display error message
                ViewBag.ErrorMessage = "Form cannot be empty";
                return View();
            }
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


                return RedirectToAction("addapplicant");
            }
            else
            {
                return Content("Form cannot be empty");
            }
           
        }

        public ActionResult applic_list()
        {
            var db = JobEnt.Applicants.ToList();
            ViewBag.Message = "Blog page";

            return View(db);
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