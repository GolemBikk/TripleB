using System.Collections.Generic;
using System.Linq;
using Models;

namespace DB.Repositories
{
    public class AccountRepository
    {
        private TripleBDbContext db;

        public AccountRepository(TripleBDbContext db)
        {
            this.db = db;
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
        /// Получение аккаунта из БД по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Account Read(int id)
        {
            return db.Accounts.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Получение всех аккаунтов из БД
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Account> Read()
        {
            return db.Accounts.ToList();
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
