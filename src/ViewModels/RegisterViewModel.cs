﻿using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class RegisterViewModel
    {
        /// <summary>
        /// Фамилия, Имя пользователя 
        /// </summary>
        [RegularExpression(@"[A-Za-zА-Яа-я]+\s[A-Za-zА-Яа-я]+", ErrorMessage = "Некорректное имя и фамилия")]
        public string UserName { get; set; }

        /// <summary>
        /// Уникальное имя пользователя
        /// </summary>
        [RegularExpression(@"[A-Za-z0-9]{4,20}", ErrorMessage = "Некорректный логин")]
        public string UserLogin { get; set; }

        /// <summary>
        /// Пароль аккаунта
        /// </summary>
        [Required(ErrorMessage = "Пароль не указан")]
        public string Password { get; set; }

        /// <summary>
        /// Подтверждение пароля аккаунта
        /// </summary>
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// Почтовый ящик пользователя
        /// </summary>
        [EmailAddress(ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; }

        /// <summary>
        /// Тип аккаунта (Поставщик, Клиент)
        /// </summary>
        [RegularExpression(@"[ПоставщикКлиент]", ErrorMessage = "Некорректный тип")]
        public string AccountType { get; set; }
    }
}
