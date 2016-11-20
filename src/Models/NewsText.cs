using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class NewsText : IEquatable<NewsText>
    {
        public int ID { get; set; }

        public string text { get; set; }

        public News news { get; set; }

        public override string ToString()
        {
            return String.Format("ID: {0}, text {1}", ID, text);
        }

        public bool Equals(NewsText other)
        {
            return this.ID == other.ID;
        }
    }
}
