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
            song.Artist = context.Artists.Find(song.ArtistId);
            song.User = context.Users.Find(song.UserId);
            if (song != null)
            {
                ViewBag.PopularSongs = context.Songs.Take(10).Include(s => s.Artist).AsNoTracking();
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