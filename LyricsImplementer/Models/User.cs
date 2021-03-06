﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LyricsImplementer.Models
{
    public class User
    {
        [ScaffoldColumn(false)]
        public int UserId { get; set; }
        [Required (ErrorMessage = "Обязательное поле")]
        [Display(Name = "Логин")]
        [Remote("CheckLogin", "Registration", ErrorMessage = "Login is already exist.")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Обязательное поле")]        [DataType(DataType.Password)]

        [Display(Name = "Пароль")]
        public string Password { get; set; }
        [Column("Nickname")]
        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Никнэйм")]
        [Remote("CheckNickname", "Registration", ErrorMessage = "Nickname is already exist.")]
        public string Nickname { get; set; }
        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Электронная почта")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        [Remote("CheckEmail", "Registration", ErrorMessage = "User with this email is already exist.")]
        public string Email { get; set; }

        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }

        [System.Web.Mvc.Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [Display(Name = "Подтверждение пароля")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }

        public DateTime RegistrationDate { get; set; }

        public virtual ICollection<Song> Songs { get; set; }
    }
}