using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Rent
    {
        /// <summary>
        /// Primary key
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Время начала аренды
        /// </summary>
        public DateTime From { get; set; }

        /// <summary>
        /// Время конца аренды
        /// </summary>
        public DateTime To { get; set; }

        /// <summary>
        /// Арендуемая лодка. Foreign key
        /// </summary>
        public int RecallId { get; set; }
    }
}
