using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LyricsImplementer.Models
{
    public class Song
    {
        public int SongId { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Notation { get; set; }

        public int? AlbumId { get; set; }
        public Album Album { get; set; }
        public virtual ICollection<Artist> Artists { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<SongLyrics> SongLyrics { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
    }
}