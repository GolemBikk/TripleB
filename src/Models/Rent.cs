using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

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
        /// Арендатор лодки. Foreign key
        /// </summary>
        public int ClientId { get; set; }
        [ForeignKey("ClientId")]
        public virtual Account Account { get; set; }

        /// <summary>
        /// Арендуемая лодка. Foreign key
        /// </summary>
        public int BoatId { get; set; }
        [ForeignKey("BoatId")]
        public Boat Boat { get; set; }
    }
}
