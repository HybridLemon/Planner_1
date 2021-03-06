﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Planner_0.Models.Planner;
using Microsoft.AspNet.Identity;
using System.Web.Security;

namespace Planner_0.Controllers
{
    public class PlannerController : Controller
    {
        private static PlannerContext DB = new PlannerContext();
        //var user = UserManager.FindById(User.Identity.GetUserId());

        public static string User_Id = System.Web.HttpContext.Current.User.Identity.GetUserId();
        

        public ActionResult StartPageView()
        {
            return View();
        }

        [Authorize]
        public ActionResult TaskView() {
            return View();
        }

        [Authorize]
        public ActionResult ListOfTaskView() {
            ViewBag.User = System.Web.HttpContext.Current.User.Identity.GetUserId();
            ViewBag.Categories = DB.Category.Where(c => c.User_ID == User_Id);
            return View();
        }

    }
}