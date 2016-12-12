﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViewModels
{
    public class AccountViewModel
    {
        /// <summary>
        /// Фамилия, Имя пользователя 
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Уникальное имя пользователя
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Почтовый ящик пользователя
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Статус пользователя (Активен, Заблокирован
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Списко лодок пользователя
        /// </summary>
        public List<BoatCollectionViewModel> Boats { get; set; }


        /// <summary>
        /// Список заявок пользователя
        /// </summary>
        public List<RecallCollectionViewModel> Recalls { get; set; }
    }
}
