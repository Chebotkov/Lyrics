using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LyricsImplementer.Models;

namespace LyricsImplementer.Controllers
{
    public class MainController : Controller
    {
        private LyricsDBContext context = new LyricsDBContext();
        // GET: Main
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult MainPage()
        {
            var PopularSongs = context.Songs.Take(10).Include(s => s.Artists).AsNoTracking();
            var Songs = context.Songs.Include(s => s.Artists).AsNoTracking();
            ViewBag.Songs = Songs;
            ViewBag.PopularSongs = PopularSongs;
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }
    }
}