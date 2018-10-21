using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LyricsImplementer.Models
{
    public class Language
    {
        public int LanguageId { get; set; }
        public string LanguageName { get; set; }

        public virtual ICollection<Lyrics> LyricsList { get; set; }
    }
}