using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class AccountType : IEquatable<AccountType>
    {
        public int ID { get; set; }

        public string type { get; set; }

        public override string ToString()
        {
            return String.Format("ID: {0}, type: {1}", ID, type);
        }

        public bool Equals(AccountType other)
        {
            return this.ID == other.ID;
        }
    }
}
