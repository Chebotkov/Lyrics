using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LyricsImplementer.Models
{
    public class Lyrics
    {
        public int LyricsId { get; set; }
        public string Text { get; set; }
        
        public int? SongId { get; set; }
        public Song Song { get; set; }
        public int? LanguageId { get; set; }
        public Language Language { get; set; }
    }
}