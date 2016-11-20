using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class BoatType : IEquatable<BoatType>
    {
        public int ID { get; set; }

        public string type { get; set; }

        public override string ToString()
        {
            return String.Format("ID: {0}, type: {1}", ID, type);
        }

        public bool Equals(BoatType other)
        {
            return this.ID == other.ID;
        }
    }
}
