using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViewModels
{
    public class RecallCollectionViewModel
    {
        /// <summary>
        /// Уникальный номер зкакза
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Уникальное имя заказчика
        /// </summary>
        public String CustomerLogin { get; set; }

        /// <summary>
        /// Тип выполняемой операции (Покупка/Аренда)
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
    }
}
