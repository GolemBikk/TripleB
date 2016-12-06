using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Boat
    {
        /// <summary>
        /// Primary key
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Скорость лодки
        /// </summary>
        public string Speed { get; set; }

        /// <summary>
        /// Стоимость покупки (аренды) лодки
        /// </summary>
        public string Cost { get; set; }

        /// <summary>
        /// Краткое описание лодки
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Текущий статус (Свободно, продано (арендовано))
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Тип лодки (Катер, Яхта)
        /// </summary>
        public string BoatType { get; set; } 

        /// <summary>
        /// Модель лодки. Foreign key
        /// </summary>
        public int ModelId { get; set; }
        [ForeignKey("ModelId")]
        public BoatModel Model { get; set; }

        /// <summary>
        /// Владелец лодки. Foreign key
        /// </summary>
        public int OwnerId { get; set; }
        [ForeignKey("OwnerId")]
        public Account Account { get; set; }

        public ICollection<Recall> Recalls { get; set; }
    }
}
