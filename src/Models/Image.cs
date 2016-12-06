using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Image
    {
        /// <summary>
        /// Primary key
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Изображение в побайтовом виде
        /// </summary>
        public byte[] Content  {get; set; }

        /// <summary>
        /// Id объекта, к которому привязывается изображение (Account, Boat, News)
        /// </summary>
        public int OwnerId { get; set; }
    }
}
