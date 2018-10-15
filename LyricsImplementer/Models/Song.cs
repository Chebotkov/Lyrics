using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LyricsImplementer.Models
{
    public class Song
    {
        public int SongId { get; set; }
        public int ArtistId { get; set; }
        public string Name { get; set; }
        public int? AlbumId { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Notation { get; set; }

        public Genre Genre { get; set; }
        //public Album ArtistAlbum { get; set; }
        public Artist Artist { get; set; }
        public User User { get; set; }
    }
}