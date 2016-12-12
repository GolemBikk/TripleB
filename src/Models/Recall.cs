using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Recall
    {
        /// <summary>
        /// Primary key
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Дата подачи
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Заинтересованное лицо. Foreign key
        /// </summary>
        public int ClientId { get; set; }

        /// <summary>
        /// Интересующая лодка. Foreign key
        /// </summary>
        public int BoatId { get; set; }
    }
}
