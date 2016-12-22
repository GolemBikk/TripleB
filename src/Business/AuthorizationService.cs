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
        public int RegisterNewAccount(RegisterViewModel data)
        {
            try
            {
                if (ContainsLogin(data.UserLogin))
                {
                    return 1;
                }
                if (ContainsEmail(data.Email))
                {
                    return 2;
                }
                Account new_account = new Account
                {
                    AccountType = data.AccountType,
                    Login = data.UserLogin,
                    Password = data.Password,
                    Email = data.Email,
                    FirstName = data.UserName.Split(' ')[0],
                    LastName = data.UserName.Split(' ')[1],
                    Status = true,
                    Cash = 0
                };
                repository.Create(new_account);
                return 0;
            }
            catch
            {
                return 3;
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
                Account result = repository.GetByLogin(login);
                if (result == null)
                {
                    return null;
                }
                AccountViewModel account = new AccountViewModel
                {
                    Id = result.Id,
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
        /// Редактирование данных аккаунта
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int EditAccount(AccountViewModel data)
        {
            try
            {
                Account new_account = repository.GetById(data.Id);
                new_account.Login = data.Login;
                new_account.Password = data.Password;
                repository.Update(new_account);
                return 0;
            }
            catch
            {
                return 1;
            }
        }


        public int AccountStatus(int id)
        {
            try
            {
                Account account = repository.GetById(id);

                account.Status = !account.Status;
                repository.Update(account);

                return 1;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Проверка, верно ли указан пароль
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int CheckPassword(LoginViewModel data)
        {
            Account result = repository.GetByLogin(data.UserLogin);
            if (result != null)
            {
                if (result.Password.Equals(data.Password))
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                return 2;
            }
        }

        /// <summary>
        /// Проверка наличия аккаунта с заданным логином
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        private bool ContainsLogin(string login)
        {
            return repository.GetByLogin(login) != null;
        }

        /// <summary>
        /// Проверка наличия аккаунта с заданным электронным адресом
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        private bool ContainsEmail(string email)
        {
            return repository.GetByEmail(email) != null;
        }
    }
}
