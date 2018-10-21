using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LyricsImplementer.Models;

namespace LyricsImplementer.Controllers
{
    public class LyricsAndTranslationController : Controller
    {
        private LyricsDBContext context = new LyricsDBContext();

        [HttpGet]
        public ActionResult SongText(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Song song = context.Songs.Find(id);
            if (song != null)
            {
                ViewBag.PopularSongs = context.Songs.Take(10).AsNoTracking();

                ViewBag.Song = song;
                return View();
            }
            return HttpNotFound();
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }
    }
}