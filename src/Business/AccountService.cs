using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DB;
using DB.Repositories;
using Models;
using ViewModels;

namespace Business
{
    public class AccountService
    {
        private AccountRepository repository;

        public AccountService(TripleBDbContext db)
        {
            repository = new AccountRepository(db);
        }

        public void AddAccount(AccountViewModel account)
        {
            Account new_account = new Account { };

        }
    }
}
