using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LyricsImplementer.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }

        public DateTime RegistrationDate { get; set; }
    }
}