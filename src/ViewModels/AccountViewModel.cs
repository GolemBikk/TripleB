using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViewModels
{
    public class AccountViewModel
    {
        public int Id { get; set; }
        /// <summary>
        /// Фамилия, Имя пользователя 
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Уникальное имя пользователя
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Пароль аккаунта
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Почтовый ящик пользователя
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Статус пользователя (Активен, Заблокирован)
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        /// Тип аккаунта (Админ, Поставщик, Клиент)
        /// </summary>
        public string AccountType { get; set; }

        /// <summary>
        /// Списко лодок пользователя
        /// </summary>
        public List<BoatCollectionViewModel> Boats { get; set; }

        /// <summary>
        /// Список заявок пользователя
        /// </summary>
        public List<MessageCollectionViewModel> Recalls { get; set; }
    }
}
