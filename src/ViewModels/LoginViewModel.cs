using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class LoginViewModel
    {
        /// <summary>
        /// Уникальное имя пользователя
        /// </summary>
        [RegularExpression(@"[A-Za-z0-9]{4,20}", ErrorMessage = "Некорректный логин")]
        public string Login { get; set; }

        /// <summary>
        /// Пароль аккаунта
        /// </summary>
        [Required(ErrorMessage = "Пароль не указан")]
        public string Password { get; set; }
    }
}
