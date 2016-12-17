namespace ViewModels
{
    public class RegisterViewModel
    {
        /// <summary>
        /// Фамилия, Имя пользователя 
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Уникальное имя пользователя
        /// </summary>
        public string UserLogin { get; set; }

        /// <summary>
        /// Пароль аккаунта
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Подтверждение пароля аккаунта
        /// </summary>
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// Почтовый ящик пользователя
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Тип аккаунта (Поставщик, Клиент)
        /// </summary>
        public string AccountType { get; set; }
    }
}
