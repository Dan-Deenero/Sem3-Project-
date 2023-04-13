using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Semester_3_project.Models;

namespace Semester_3_project.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {

        public ActionResult ExternalLoginFailure()
        {
            return View();
        }
       
    }
}