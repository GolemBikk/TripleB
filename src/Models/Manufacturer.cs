using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Manufacturer : IEquatable<Manufacturer>
    {
        public int ID { get; set; }

        public string name { get; set; }

        public override string ToString()
        {
            return String.Format("ID: {0}, name: {1}", ID, name);
        }

        public bool Equals(Manufacturer other)
        {
            return this.ID == other.ID;
        }
    }
}
