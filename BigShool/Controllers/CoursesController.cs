﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BigSchool.ViewModels;
using BigSchool.Models;
using Microsoft.AspNet.Identity;

namespace BigSchool.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public CoursesController()
        {
            _dbContext = new ApplicationDbContext();
        }

        // GET: Courses
        // Authorize chỉ cho phép truy cập vào /Courses/Create khi có tài khoản
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new CourseViewModels
            {
                Categories = _dbContext.Categories.ToList()
            };

            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseViewModels viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categories = _dbContext.Categories.ToList();
                return View("Create", viewModel);
            }
            var course = new Course
            {
                LecturerId = User.Identity.GetUserId(),
                DateTime = viewModel.GetDateTime(),
                CategoryId = viewModel.Category,
                Place = viewModel.Place
            };
            _dbContext.Courses.Add(course);
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}