using System;
using System.Collections.Generic;
using DB.Repositories;
using Models;
using ViewModels;

namespace Business
{
    public class AccountService
    {
        private AccountRepository repository;

        public AccountService()
        {
            repository = new AccountRepository();
        }

        public void AddAccount(AccountViewModel account)
        {
            Account new_account = new Account {Login = account.Login,
                                                FirstName = account.Username.Split(' ')[0],
                                                LastName = account.Username.Split(' ')[1],
                                                Password = account.Password,
                                                Email = account.Email,
                                                Status = true,
                                                Cash = 0,
                                                AccountType = account.AccountType};
            repository.Create(new_account);
        }

        public List<AccountViewModel> GetAllAccounts()
        {
            List<AccountViewModel> accounts = new List<AccountViewModel>();
            IEnumerable<Account> result = repository.Read();
            foreach (Account item in result)
            {
                AccountViewModel account = new AccountViewModel
                {
                    Login = item.Login,
                    Username = String.Format("{0} {1}", item.FirstName, item.LastName),
                    Email = item.Email,
                    Status = item.Status,
                    AccountType = item.AccountType
                };
                accounts.Add(account);
            }
            return accounts;
        }
    }
}
