using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViewModels
{
    public class BoatCollectionViewModel
    {
        /// <summary>
        /// Уникальный номер модели
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Модель лодки
        /// </summary>
        public String BoatModel { get; set; }

        /// <summary>
        /// Фото лодки
        /// </summary>
        public Byte[] Image { get; set; }

        /// <summary>
        /// Описание лодки
        /// </summary>
        public String Discription { get; set; }
    }
}
