using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LyricsImplementer.Models
{
    public class Album
    {
        public string AlbumId { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Length { get; set; }
        public string Notation { get; set; }

        //list of songs
    }
}