using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class LoginViewModel
    {
        /// <summary>
        /// Уникальное имя пользователя
        /// </summary>
<<<<<<< .merge_file_a03844
        public string UserLogin { get; set; }
=======
        [RegularExpression(@"[A-Za-z0-9]{4,20}", ErrorMessage = "Некорректный логин")]
        public string Login { get; set; }
>>>>>>> .merge_file_a08536

        /// <summary>
        /// Пароль аккаунта
        /// </summary>
        [Required(ErrorMessage = "Пароль не указан")]
        public string Password { get; set; }
    }
}
