using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class BoatModel : IEquatable<BoatModel>
    {
        public int ID { get; set; }
       
        public string length { get; set; }

        public string height { get; set; }

        public string width { get; set; }

        public Manufacturer manufacturer { get; set; }

        public override string ToString()
        {
            return String.Format("ID: {0}, length: {1}, height: {2}, width: {3}", ID, length, height, width);
        }

        public bool Equals(BoatModel other)
        {
            return this.ID == other.ID;
        }
    }
}
