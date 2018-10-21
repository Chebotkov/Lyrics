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

        public virtual ICollection<Song> Songs { get; set; }
        public virtual ICollection<Language> Languages { get; set; }

    }
}