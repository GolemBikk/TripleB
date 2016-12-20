using System.Linq;
using Models;

namespace DB.Repositories
{
    public class AccountRepository
    {
        /// <summary>
        /// Добавление аккаунта в БД
        /// </summary>
        /// <param name="account"></param>
        public void Create(Account account)
        {
            using (TripleBDbContext db = new TripleBDbContext())
            {
                if (account != null)
                {
                    db.Accounts.Add(account);
                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Получение аккаунта из БД по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Account GetById(int id)
        {
            using (TripleBDbContext db = new TripleBDbContext())
            {
                return db.Accounts.FirstOrDefault(x => x.Id == id);
            }
        }

        /// <summary>
        /// Получение аккаунта из БД по логину
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Account GetByLogin(string login)
        {
            using (TripleBDbContext db = new TripleBDbContext())
            {
                return db.Accounts.FirstOrDefault(x => x.Login == login);
            }
        }

        /// <summary>
        /// Получение аккаунта из БД по электронному адресу
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Account GetByEmail(string email)
        {
            using (TripleBDbContext db = new TripleBDbContext())
            {
                return db.Accounts.FirstOrDefault(x => x.Email == email);
            }
        }

        /// <summary>
        /// Обновление данных аккаунта в БД
        /// </summary>
        /// <param name="account"></param>
        public void Update(Account account)
        {
            using (TripleBDbContext db = new TripleBDbContext())
            {
                Account old_account = db.Accounts.FirstOrDefault(x => x.Login == account.Login),
                    new_account = old_account;
                new_account.Password = account.Password;
                if (account != null)
                {
                    db.Accounts.Update(new_account);
                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Удаление аккаунта из БД
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            using (TripleBDbContext db = new TripleBDbContext())
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
}
