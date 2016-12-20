using Models;
using System.Collections.Generic;
using System.Linq;

namespace DB.Repositories
{
    public class BoatRepository
    {
        /// <summary>
        /// Добавление лодки в БД
        /// </summary>
        /// <param name="boat"></param>
        public int Boat_Create(Boat boat)
        {
            using (TripleBDbContext db = new TripleBDbContext())
            {
                if (boat != null)
                {
                    db.Boats.Add(boat);
                    db.SaveChanges();
                }
                return boat.Id;
            }
        }
       
        /// <summary>
        /// Получение лодки из БД по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Boat Boat_GetById(int id)
        {
            using (TripleBDbContext db = new TripleBDbContext())
            {
                return db.Boats.FirstOrDefault(x => x.Id == id);
            }
        }

        /// <summary>
        /// Возвращает последнюю лодку из списка
        /// </summary>
        /// <returns></returns>
        public Boat Boat_GetLast()
        {
            using (TripleBDbContext db = new TripleBDbContext())
            {
                return db.Boats.ToList().Last();
            }
        }

        /// <summary>
        /// Получение всех лодок из БД
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Boat> Boat_GetAll(string kind)
        {
            using (TripleBDbContext db = new TripleBDbContext())
            {
                return db.Boats.Where(x => x.Kind.Equals(kind)).ToList();
            }
        }

        /// <summary>
        /// Получение лодок из БД для указанного пользователя
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Boat> Boat_GetByUserId(int owner_id)
        {
            using (TripleBDbContext db = new TripleBDbContext())
            {
                return db.Boats.Where(x => x.OwnerId == owner_id).ToList();
            }
        }

        /// <summary>
        /// Обновление данных лодки в БД
        /// </summary>
        /// <param name="boat"></param>
        public void Boat_Update(Boat boat)
        {
            using (TripleBDbContext db = new TripleBDbContext())
            {
                if (boat != null)
                {
                    db.Boats.Update(boat);
                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Удаление лодки из БД
        /// </summary>
        /// <param name="id"></param>
        public void Boat_Delete(int id)
        {
            using (TripleBDbContext db = new TripleBDbContext())
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
}
