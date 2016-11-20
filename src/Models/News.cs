using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class News : IEquatable<News>
    {
        public int ID { get; set; }

        public string title { get; set; }

        public DateTime date { get; set; }

        public override string ToString()
        {
            return String.Format("ID: {0}, title {1}, date: {2}", ID, title, date.ToString());
        }

        public bool Equals(News other)
        {
            return this.ID == other.ID;
        }
    }
}
