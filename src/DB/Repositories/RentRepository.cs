using Models;
using System.Collections.Generic;
using System.Linq;

namespace DB.Repositories
{
    public class RentRepository
    {
        private TripleBDbContext db;

        public RentRepository(TripleBDbContext db)
        {
            this.db = db;
        }

        /// <summary>
        /// Добавление договора аренды в БД
        /// </summary>
        /// <param name="rent"></param>
        public void Create(Rent rent)
        {
            if (rent != null)
            {
                db.Rents.Add(rent);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Получение договора аренды из БД по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Rent Read(int id)
        {
            return db.Rents.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Получение всех договоров аренды из БД
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Rent> Read()
        {
            return db.Rents.ToList();
        }

        /// <summary>
        /// Обновление данных договора аренды в БД
        /// </summary>
        /// <param name="rent"></param>
        public void Update(Rent rent)
        {
            if (rent != null)
            {
                db.Rents.Update(rent);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Удаление договора аренды из БД
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            Rent rent = db.Rents.FirstOrDefault(x => x.Id == id);
            if (rent != null)
            {
                db.Rents.Remove(rent);
                db.SaveChanges();
            }
        }
    }
}
