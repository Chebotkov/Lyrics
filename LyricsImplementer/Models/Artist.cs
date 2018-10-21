using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LyricsImplementer.Models
{
    public class Artist
    {
        public int ArtistId { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public DateTime Birth { get; set; }
        public string Origin { get; set; }
        public string YearsActive { get; set; }

        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }

        public virtual ICollection<Song> Songs { get; set; }
        public virtual ICollection<Album> Albums { get; set; }
    }
}