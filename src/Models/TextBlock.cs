using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class TextBlock
    {
        /// <summary>
        /// Primary key
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Текстовый блок
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Номер в последовательности
        /// </summary>
        public int Rank { get; set; }

        /// <summary>
        /// Id объекта, к которому привязывается текстовый блок (Boat, News)
        /// </summary>
        public int OwnerId { get; set; }
    }
}
