using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViewModels
{
    public class RentViewModel
    {
        /// <summary>
        /// Дата начала аренды
        /// </summary>
        public DateTime StatusFrom { get; set; }

        /// <summary>
        /// Дата окончания аренды
        /// </summary>
        public DateTime StatusTo { get; set; }
    }
}
