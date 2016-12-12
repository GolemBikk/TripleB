using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class BoatModel
    {
        /// <summary>
        /// Primary key
        /// </summary>
        [Key]
        public int Id { get; set; }
       
        /// <summary>
        /// Наименование модели
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Длина лодки
        /// </summary>
        public string Length { get; set; }

        /// <summary>
        /// Высота лодки
        /// </summary>
        public string Height { get; set; }

        /// <summary>
        /// Ширина лодки
        /// </summary>
        public string Width { get; set; }

        /// <summary>
        /// Производитель модели.
        /// </summary>
        public string ManufacturerName { get; set; }
    }
}
