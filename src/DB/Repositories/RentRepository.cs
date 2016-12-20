using Models;
using System.Collections.Generic;
using System.Linq;

namespace DB.Repositories
{
    public class RentRepository
    {
        /// <summary>
        /// Добавление договора аренды в БД
        /// </summary>
        /// <param name="rent"></param>
        public void Create(Rent rent)
        {
            using (TripleBDbContext db = new TripleBDbContext())
            {
                if (rent != null)
                {
                    db.Rents.Add(rent);
                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Получение договора аренды из БД по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Rent Read(int id)
        {
            using (TripleBDbContext db = new TripleBDbContext())
            {
                return db.Rents.FirstOrDefault(x => x.Id == id);
            }
        }

        /// <summary>
        /// Получение всех договоров аренды для указанной лодки
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Rent> GetByOwnerId(int owner_id)
        {
            using (TripleBDbContext db = new TripleBDbContext())
            {
                return db.Rents.Where(x => x.RecallId == owner_id).ToList();
            }
        }

        /// <summary>
        /// Получение всех договоров аренды из БД
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Rent> Read()
        {
            using (TripleBDbContext db = new TripleBDbContext())
            {
                return db.Rents.ToList();
            }
        }

        /// <summary>
        /// Обновление данных договора аренды в БД
        /// </summary>
        /// <param name="rent"></param>
        public void Update(Rent rent)
        {
            using (TripleBDbContext db = new TripleBDbContext())
            {
                if (rent != null)
                {
                    db.Rents.Update(rent);
                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Удаление договора аренды из БД
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            using (TripleBDbContext db = new TripleBDbContext())
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
}
