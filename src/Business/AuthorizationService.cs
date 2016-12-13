using System;
using System.Collections.Generic;
using DB.Repositories;
using Models;
using ViewModels;

namespace Business
{
    public class AuthorizationService
    {
        private AccountRepository repository;

        public AuthorizationService()
        {
            repository = new AccountRepository();
        }

        /// <summary>
        /// Добавление нового аккаунта в БД
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public int RegisterNewAccount(AccountViewModel data)
        {
            try
            {
                if (ContainsAccount(data.Login))
                {
                    return 1;
                }
                Account new_account = new Account
                {
                    AccountType = data.AccountType,
                    Login = data.Login,
                    Password = data.Password,
                    Email = data.Email,
                    FirstName = data.Username.Split(' ')[0],
                    LastName = data.Username.Split(' ')[1],
                    Status = true,
                    Cash = 0
                };
                repository.Create(new_account);
                return 0;
            }
            catch
            {
                return 2;
            }
        }

        /// <summary>
        /// Получение информации об аккаунте
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public AccountViewModel GetAccountInfo(string login)
        {
            try
            {              
                Account result = repository.Read(login);
                if (result == null)
                {
                    return null;
                }
                AccountViewModel account = new AccountViewModel
                {
                    Login = result.Login,
                    Username = String.Format("{0} {1}", result.FirstName, result.LastName),
                    Email = result.Email,
                    Status = result.Status,
                    AccountType = result.AccountType
                };
                return account;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Проверка, верно ли указан пароль
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool CheckPassword(string login, string password)
        {
            Account result = repository.Read(login);
            if (result != null)
            {
                return result.Password.Equals(password);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Проверка наличия аккаунта с заданным логином
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        private bool ContainsAccount(string login)
        {
            return repository.Read(login) != null;
        }       
    }
}
