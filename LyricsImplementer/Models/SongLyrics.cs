using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LyricsImplementer.Models
{
    public class SongLyrics
    {
        public int? SongId { get; set; }
        public int? LyricsId { get; set; }
        public int? LanguageId { get; set; }
    }
}