using Models;
using System.Collections.Generic;
using System.Linq;

namespace DB.Repositories
{
    public class BoatRepository
    {
        private TripleBDbContext db;

        public BoatRepository(TripleBDbContext db)
        {
            this.db = db;
        }

        /// <summary>
        /// Добавление лодки в БД
        /// </summary>
        /// <param name="boat"></param>
        public void Create(Boat boat)
        {
            if (boat != null)
            {
                db.Boats.Add(boat);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Получение лодки из БД по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Boat Read(int id)
        {
            return db.Boats.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Получение всех лодок из БД
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Boat> Read()
        {
            return db.Boats.ToList();
        }

        /// <summary>
        /// Обновление данных лодки в БД
        /// </summary>
        /// <param name="boat"></param>
        public void Update(Boat boat)
        {
            if (boat != null)
            {
                db.Boats.Update(boat);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Удаление лодки из БД
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            Boat boat = db.Boats.FirstOrDefault(x => x.Id == id);
            if (boat != null)
            {
                db.Boats.Remove(boat);
                db.SaveChanges();
            }
        }
    }
}
