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
        public string Status { get; set; }

        /// <summary>
        /// Тип аккаунта (Админ, Поставщик, Обычный)
        /// </summary>
        public string AccountType { get; set; }
     
        /// <summary>
        /// Информация о аренде лодки
        /// </summary>
        public virtual Rent Rent { get; set; }

        public ICollection<Boat> Boats { get; set; }

        public ICollection<Recall> Recalls { get; set; }
    }
}
