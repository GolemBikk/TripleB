using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Boat : IEquatable<Boat>
    {
        public int ID { get; set; }

        public string speed { get; set; }

        public string cost { get; set; }

        public string description { get; set; }

        public bool status { get; set; }

        public DateTime status_from { get; set; }

        public DateTime status_to { get; set; }

        public Account status_client { get; set; }

        public BoatType type { get; set; }

        public BoatModel model { get; set; }

        public Account owner { get; set; }

        public override string ToString()
        {
            return String.Format("ID: {0}, speed: {1}, cost: {2}, status: {3}", ID, speed, cost, status);
        }

        public bool Equals(Boat other)
        {
            return this.ID == other.ID;
        }
    }
}
