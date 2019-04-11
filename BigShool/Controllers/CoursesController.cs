using BigSchool.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace BigSchool.Controllers.Api
{
    public class CoursesController : ApiController
    {
        private ApplicationDbContext _dbContext;
        public CoursesController()
        {
            _dbContext = new ApplicationDbContext();
        }

        public object User { get; private set; }

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userId = User.Identity.GetUserId();
            var courses = _dbContext.Courses.Single(c => c.Id == id && c.LecturerId == userId);
            if (courses.IsCanceled)
            {
                return NotFound();
            }
            courses.IsCanceled = true;
            _dbContext.SaveChanges();
            return Ok();
        }

        private IHttpActionResult Ok()
        {
            throw new NotImplementedException();
        }

        private IHttpActionResult NotFound()
        {
            throw new NotImplementedException();
        }
    }
}
