using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LyricsImplementer.Models;

namespace LyricsImplementer.Classes
{
    public class Helper
    {
        public static string GetArtists(ICollection<Artist> Artists)
        {
            List<Artist> artists = Artists.ToList(); 

            if (artists.Count == 0)
            {
                return "";    
            }
            if (artists.Count == 1)
            {
                return artists[0].Nickname;
            }

            string fullArtist = artists[0].Nickname;

            for (int i = 1; i < Artists.Count; i++)
            {
                fullArtist += String.Format("ft. {0}", artists[i].Nickname);
            }

            return fullArtist;
        }
    }
}