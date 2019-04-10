using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BigSchool.Models;

namespace BigSchool.Controllers
{
    public class HomeController : Controller
    {

        private ApplicationDbContext _dbContext;

        public HomeController()
        {
            _dbContext = new ApplicationDbContext();
        }

        public ActionResult Index()
        {

            var upcommingCourses = _dbContext.Courses.Include("Lecturer").Include("Category").Where(c => c.DateTime > DateTime.Now).OrderBy(m => m.DateTime);

            return View(upcommingCourses);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}