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
        private int englishText = 1;
        private int russianText = 2;

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
                ViewBag.PopularSongs = context.Songs.Take(10).Include(s => s.Artists).AsNoTracking();
                Song ss = context.Songs.Where(s => s.SongId == id).Include(s => s.LyricsList).FirstOrDefault();
                ss.LyricsList = ss.LyricsList.Where(lg => lg.LanguageId == englishText || lg.LanguageId == russianText).ToList();
                ss.User = context.Users.Find(ss.UserId);
                ViewBag.Song = ss;

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