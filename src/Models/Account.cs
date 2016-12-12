using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Account
    {
        /// <summary>
        /// Primary key
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Логин аккаунта
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Пароль аккаунта
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Токен доступа пользователя, авторизованного через соц. сеть
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Электронный адрес
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Текущий статус аккаунта (Активный, Заблокированный)
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        /// Счёт пользователя
        /// </summary>
        public int Cash { get; set; }

        /// <summary>
        /// Тип аккаунта (Админ, Поставщик, Обычный)
        /// </summary>
        public string AccountType { get; set; }
        
        /// <summary>
        /// Информация об аренде лодки
        /// </summary>
        public int RentId { get; set; }
    }
}
