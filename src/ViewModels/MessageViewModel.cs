using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViewModels
{
    public class MessageViewModel
    {
        /// <summary>
        /// Уникальный номер заказа
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Уникальный номер лодки
        /// </summary>
        public int BoatId { get; set; }

        /// <summary>
        /// Уникально имя заказчика
        /// </summary>
        public String CustomerLogin { get; set; }

        /// <summary>
        /// Тип выполняемой операции
        /// </summary>
        public String Operation { get; set; }

        /// <summary>
        /// Дата поступления заявки
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Модель заказываемой лодки
        /// </summary>
        public String BoatModel { get; set; }

        /// <summary>
        /// Сообщение заказчика
        /// </summary>
        public String CustomerMessage { get; set; }

        /// <summary>
        /// Массив фотографий лодки
        /// </summary>
        public Byte[] Image { get; set; }
    }
}
