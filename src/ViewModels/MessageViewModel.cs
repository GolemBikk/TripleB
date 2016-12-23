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
        /// 
        /// </summary>
        public string BoatModel { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int ClientId { get; set; }

        /// <summary>
        /// Уникальный номер лодки
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Уникально имя заказчика
        /// </summary>
        public String Login { get; set; }

        /// <summary>
        /// Тип выполняемой операции
        /// </summary>
        public String Operation { get; set; }

        /// <summary>
        /// Дата поступления заявки
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Сообщение заказчика
        /// </summary>
        public String Text { get; set; }
    }
}
