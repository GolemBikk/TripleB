using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Message
    {
        /// <summary>
        /// Primary key
        /// </summary>
        [Key]
        public int Id { get; set; }

        public string Text { get; set; }

        public string Type { get; set; }

        /// <summary>
        /// Дата подачи
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// От кого. Foreign key
        /// </summary>
        public int FromId { get; set; }

        /// <summary>
        /// Кому. Foreign key
        /// </summary>
        public int ToId { get; set; }

        /// <summary>
        /// Интересующая лодка. Foreign key
        /// </summary>
        public int BoatId { get; set; }
    }
}
