using SklepUKW.DAL;
using SklepUKW.Models;
using SklepUKW.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SklepUKW.Controllers
{
    public class HomeController : Controller
    {
        FilmsContext db = new FilmsContext();

        // GET: Home
        public ActionResult Index()
        {
            var top3LongestFilms = db.Films.OrderByDescending(f => f.Length).Take(3).ToList();
            return View(top3LongestFilms);
        }

        public ActionResult StaticSite(string name)
        {
            return View(name);
        }

        public ActionResult Test()
        {
            return View();
        }
    }
}