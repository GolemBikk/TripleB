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
        public int Owner { get; set; }

        /// <summary>
        /// Название лодки
        /// </summary>
        [RegularExpression(@"[A-Za-zА-Яа-я]+", ErrorMessage = "Некорректное название судна")]
        public string BoatModel { get; set; }

        /// <summary>
        /// Фотографии лодки
        /// </summary>
        public List<byte[]> Images { get; set; }

        /// <summary>
        /// Полное описание лодки
        /// </summary>
        [Required(ErrorMessage = "Нет описания судна")]
        public string Description { get; set; }

        /// <summary>
        /// Стоимость лодки
        /// </summary>
        [RegularExpression(@"[0-9]+", ErrorMessage = "Некорректная стоимость судна")]
        public int Cost { get; set; }

        /// <summary>
        /// Крейсерская скорость лодки
        /// </summary>
        [RegularExpression(@"[0-9]+", ErrorMessage = "Некоррректная скорость судна")]
        public int Speed { get; set; }

        /// <summary>
        /// Статус лодки (В наличии/Нет в наличии)
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        /// Вид предоставляемой услуги (покупка, аренда)
        /// </summary>
        public string Kind { get; set; }

        /// <summary>
        /// Тип лодки (Яхта/Катер)
        /// </summary>
        public String Type { get; set; }

        /// <summary>
        /// Длинна лодки
        /// </summary>
        [RegularExpression(@"[0-9]+", ErrorMessage = "Некоррректная длинна судна")]
        public int Lenght { get; set; }

        /// <summary>
        /// Ширина лодки
        /// </summary>
        [RegularExpression(@"[0-9]+", ErrorMessage = "Некоррректная ширина судна")]
        public int Width { get; set; }

        /// <summary>
        /// Водоизмещение лодки
        /// </summary>
        [RegularExpression(@"[0-9]+", ErrorMessage = "Некоррректное водоизмещение судна")]
        public int Displacement { get; set; }

        /// <summary>
        /// Производитель модели.
        /// </summary>
        public string ManufacturerName { get; set; }      

        /// <summary>
        /// Все данные по аренде лодки
        /// </summary>
        public List<RentViewModel> Rents { get; set; }
    }
}
