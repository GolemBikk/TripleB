using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViewModels
{
    public class NewsCollectionViewModel
    {
        /// <summary>
        /// Уникальный номер новости
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Заголовок новости
        /// </summary>
        public String Title { get; set; }

        /// <summary>
        /// Описание новости
        /// </summary>
        public String Discription { get; set; }

        /// <summary>
        /// Дата публикации новости
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Картинка новости
        /// </summary>
        public Byte[] Image { get; set; }
    }
}
