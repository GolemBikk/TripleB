﻿using System;
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
        /// Заинтересованное лицо
        /// </summary>
        public int ClientId { get; set; }
        [ForeignKey("ClientId")]
        public Account Client { get; set; }

        /// <summary>
        /// Интересующая лодка
        /// </summary>
        public int BoatId { get; set; }
        [ForeignKey("BoatId")]
        public Boat Boat { get; set; }
    }
}
