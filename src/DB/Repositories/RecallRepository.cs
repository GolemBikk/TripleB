using Models;
using System.Collections.Generic;
using System.Linq;

namespace DB.Repositories
{
    public class RecallRepository
    {
        private TripleBDbContext db;

        public RecallRepository(TripleBDbContext db)
        {
            this.db = db;
        }

        /// <summary>
        /// Добавление заявки в БД
        /// </summary>
        /// <param name="recall"></param>
        public void Create(Recall recall)
        {
            if (recall != null)
            {
                db.Recalls.Add(recall);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Получение заявки из БД по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Recall Read(int id)
        {
            return db.Recalls.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Получение всех заявок из БД
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Recall> Read()
        {
            return db.Recalls.ToList();
        }

        /// <summary>
        /// Обновление данных заявки в БД
        /// </summary>
        /// <param name="recall"></param>
        public void Update(Recall recall)
        {
            if (recall != null)
            {
                db.Recalls.Update(recall);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Удаление заявки из БД
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
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
