using System.Collections.Generic;
using System.Linq;
using Models;

namespace DB.Repositories
{
    public class AccountRepository
    {
        private TripleBDbContext db;

        public AccountRepository()
        {
            db = new TripleBDbContext();
        }

        /// <summary>
        /// Добавление аккаунта в БД
        /// </summary>
        /// <param name="account"></param>
        public void Create(Account account)
        {
            if (account != null)
            {
                db.Accounts.Add(account);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Получение аккаунта из БД по логину
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Account Read(string login)
        {
            return db.Accounts.FirstOrDefault(x => x.Login == login);
        }

        /// <summary>
        /// Обновление данных аккаунта в БД
        /// </summary>
        /// <param name="account"></param>
        public void Update(Account account)
        {
            if (account != null)
            {
                db.Accounts.Update(account);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Удаление аккаунта из БД
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            Account account = db.Accounts.FirstOrDefault(x => x.Id == id);
            if (account != null)
            {
                db.Accounts.Remove(account);
                db.SaveChanges();
            }
        }
    }
}
