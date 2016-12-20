using Models;
using System.Collections.Generic;
using System.Linq;

namespace DB.Repositories
{
    public class RecallRepository
    {
        /// <summary>
        /// Добавление заявки в БД
        /// </summary>
        /// <param name="recall"></param>
        public void Create(Recall recall)
        {
            using (TripleBDbContext db = new TripleBDbContext())
            {
                if (recall != null)
                {
                    db.Recalls.Add(recall);
                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Получение заявки из БД по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Recall Read(int id)
        {
            using (TripleBDbContext db = new TripleBDbContext())
            {
                return db.Recalls.FirstOrDefault(x => x.Id == id);
            }
        }        

        public IEnumerable<Recall> GetAllByBoat(int boat_id)
        {
            using (TripleBDbContext db = new TripleBDbContext())
            {
                return db.Recalls.Where(x => x.BoatId == boat_id).ToList();
            }
        }

        public IEnumerable<Recall> GetAllByClient(int client_id)
        {
            using (TripleBDbContext db = new TripleBDbContext())
            {
                return db.Recalls.Where(x => x.ClientId == client_id).ToList();
            }
        }

        /// <summary>
        /// Получение всех заявок из БД
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Recall> Read()
        {
            using (TripleBDbContext db = new TripleBDbContext())
            {
                return db.Recalls.ToList();
            }
        }

        /// <summary>
        /// Обновление данных заявки в БД
        /// </summary>
        /// <param name="recall"></param>
        public void Update(Recall recall)
        {
            using (TripleBDbContext db = new TripleBDbContext())
            {
                if (recall != null)
                {
                    db.Recalls.Update(recall);
                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Удаление заявки из БД
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            using (TripleBDbContext db = new TripleBDbContext())
            {
                Recall recall = db.Recalls.FirstOrDefault(x => x.Id == id);
                if (recall != null)
                {
                    db.Recalls.Remove(recall);
                    db.SaveChanges();
                }
            }
        }
    }
}
