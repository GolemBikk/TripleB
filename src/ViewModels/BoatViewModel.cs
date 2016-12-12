using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViewModels
{
    public class BoatViewModel
    {
        /// <summary>
        /// Уникальный номер лодки
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Владелец лодки
        /// </summary>
        public String Owner { get; set; }

        /// <summary>
        /// Название лодки
        /// </summary>
        public String BoatModel { get; set; }

        /// <summary>
        /// Фотографии лодки
        /// </summary>
        public List<Byte[]> Images { get; set; }

        /// <summary>
        /// Полное описание лодки
        /// </summary>
        public String Discription { get; set; }

        /// <summary>
        /// Стоимость лодки
        /// </summary>
        public int Coast { get; set; }

        /// <summary>
        /// Крейсерская скорость лодки
        /// </summary>
        public int Speed { get; set; }

        /// <summary>
        /// Статус лодки (В наличии/Нет в наличии)
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        /// Тип лодки (Яхта/Катер)
        /// </summary>
        public String Type { get; set; }

        /// <summary>
        /// Длинна лодки
        /// </summary>
        public int Lenght { get; set; }

        /// <summary>
        /// Ширина лодки
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Водоизмещение лодки
        /// </summary>
        public int Displacement { get; set; }

        /// <summary>
        /// Дата начала аренды
        /// </summary>
        public DateTime StatusFrom { get; set; }

        /// <summary>
        /// Дата окончания аренды
        /// </summary>
        public DateTime StatusTo { get; set; }
    }
}
