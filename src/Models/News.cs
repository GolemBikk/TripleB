using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class News
    {
        /// <summary>
        /// Primary key
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Заголовок новости
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Анонс новости
        /// </summary>
        public string Preview { get; set; }

        /// <summary>
        /// Дата публикации
        /// </summary>
        public DateTime Date { get; set; }
    }
}
