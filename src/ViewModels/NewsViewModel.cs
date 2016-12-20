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
        [RegularExpression(@"[A-Z][a-z][А-Я][а-я]", ErrorMessage = "Нет заголовка")]
        public String Title { get; set; }

        /// <summary>
        /// Полное описани новости
        /// </summary>
        public String Discription { get; set; }

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
