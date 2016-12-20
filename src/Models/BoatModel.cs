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
        public int Length { get; set; }

        /// <summary>
        /// Высота лодки
        /// </summary>
        public int Displacement { get; set; }

        /// <summary>
        /// Ширина лодки
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Производитель модели.
        /// </summary>
        public string ManufacturerName { get; set; }
    }
}
