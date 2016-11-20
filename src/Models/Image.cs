using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Image : IEquatable<Image>
    {
        public int ID { get; set; }

        public byte[] content  {get; set; }

        public int owner_ID { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }

        public bool Equals(Image other)
        {
            return this.ID == other.ID;
        }
    }
}
