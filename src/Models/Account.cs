using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Account : IEquatable<Account>
    {
        public string login { get; set; }

        public string password { get; set; }

        public string token { get; set; }

        public string first_name { get; set; }

        public string last_name { get; set; }

        public string email { get; set; }

        public AccountType account_type { get; set; }

        public string status { get; set; }

        public override string ToString()
        {
            return String.Format("login: {0}, password: {1}, email: {2}, status: {3}", login, password, email, status);
        }

        public bool Equals(Account other)
        {
            return this.login.Equals(other.login);
        }
    }
}
