using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Recall : IEquatable<Recall>
    {
        public int ID { get; set; }

        public string text { get; set; }

        public DateTime date { get; set; }

        public Account owner { get; set; }

        public int destination_id { get; set; }

        public override string ToString()
        {
            return String.Format("ID: {0}, text: {1}, date: {2}, dastination_id: {3}", ID, text, date.ToString(), destination_id);
        }

        public bool Equals(Recall other)
        {
            return this.ID == other.ID;
        }
    }
}
