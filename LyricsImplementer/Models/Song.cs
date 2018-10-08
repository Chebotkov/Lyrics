using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LyricsImplementer.Models
{
    public class Song
    {
        public int Id { get; set; }
        public int ArtistId { get; set; }
        public string Name { get; set; }
        
        public int? GenreId { get; set; }
        public int? Album { get; set; }
    }
}