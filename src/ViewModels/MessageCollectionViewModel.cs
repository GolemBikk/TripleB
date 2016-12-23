using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViewModels
{
    public class MessageCollectionViewModel
    {
        /// <summary>
        /// Уникальный номер заказа
        /// </summary>
        public int Id { get; set; }

        public string Text { get; set; }

        /// <summary>
        /// Уникальное имя заказчика
        /// </summary>
        public string UserLogin { get; set; }

        /// <summary>
        /// Тип выполняемой операции (Покупка/Аренда)
        /// </summary>
        public string Operation { get; set; }

        /// <summary>
        /// Дата поступления заявки
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Модель заказываемой лодки
        /// </summary>
        public string BoatModel { get; set; }
    }
}
