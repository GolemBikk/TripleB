using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [RegularExpression(@"[A-Z][a-z][А-Я][а-я]", ErrorMessage = "Некорректное название судна")]
        public String BoatModel { get; set; }

        /// <summary>
        /// Фотографии лодки
        /// </summary>
        public List<Byte[]> Images { get; set; }

        /// <summary>
        /// Полное описание лодки
        /// </summary>
        [Required(ErrorMessage = "Нет описания судна")]
        public String Discription { get; set; }

        /// <summary>
        /// Стоимость лодки
        /// </summary>
        [RegularExpression(@"[0-9]", ErrorMessage = "Некорректная стоимость судна")]
        public int Coast { get; set; }

        /// <summary>
        /// Крейсерская скорость лодки
        /// </summary>
        [RegularExpression(@"[0-9]", ErrorMessage = "Некоррректная скорость судна")]
        public int Speed { get; set; }

        /// <summary>
        /// Статус лодки (В наличии/Нет в наличии)
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        /// Тип лодки (Яхта/Катер)
        /// </summary>
        [RegularExpression(@"[ЯхтаКатер]", ErrorMessage = "Некорректный статус")]
        public String Type { get; set; }

        /// <summary>
        /// Длинна лодки
        /// </summary>
        [RegularExpression(@"[0-9]", ErrorMessage = "Некоррректная длинна судна")]
        public int Lenght { get; set; }

        /// <summary>
        /// Ширина лодки
        /// </summary>
        [RegularExpression(@"[0-9]", ErrorMessage = "Некоррректная ширина судна")]
        public int Width { get; set; }

        /// <summary>
        /// Водоизмещение лодки
        /// </summary>
        [RegularExpression(@"[0-9]", ErrorMessage = "Некоррректное водоизмещение судна")]
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
