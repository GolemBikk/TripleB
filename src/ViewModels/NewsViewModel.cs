using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ViewModels
{
    public class NewsViewModel
    {
        /// <summary>
        /// Уникальный номер новсти
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Заголовок новсти
        /// </summary>
        [RegularExpression(@"[A-Za-zА-Яа-я]+", ErrorMessage = "Нет заголовка")]
        public String Title { get; set; }

        /// <summary>
        /// Анонс новости
        /// </summary>
        [Required(ErrorMessage = "Не указан анонс")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Длина анонса должна быть от 2 до 100 символов")]
        public String Discription { get; set; }

        /// <summary>
        /// Полный текст новости
        /// </summary>
        [Required(ErrorMessage = "Введите текст новости")]
        public List<string> Text { get; set; }

        /// <summary>
        /// Дата публикации новости
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Массив фотографий новости
        /// </summary>
        public List<Byte[]> Images { get; set; }
    }
}
