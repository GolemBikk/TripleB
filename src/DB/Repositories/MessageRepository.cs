using Models;
using System.Collections.Generic;
using System.Linq;

namespace DB.Repositories
{
    public class MessageRepository
    {
        /// <summary>
        /// Добавление заявки в БД
        /// </summary>
        /// <param name="recall"></param>
        public int Create(Message recall)
        {
            using (TripleBDbContext db = new TripleBDbContext())
            {
                if (recall != null)
                {
                    db.Messages.Add(recall);
                    db.SaveChanges();
                }
            }
            return recall.Id;
        }

        /// <summary>
        /// Получение заявки из БД по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Message Read(int id)
        {
            using (TripleBDbContext db = new TripleBDbContext())
            {
                return db.Messages.FirstOrDefault(x => x.Id == id);
            }
        }

        /// <summary>
        /// Получить все заявки для лодки
        /// </summary>
        /// <param name="boat_id"></param>
        /// <returns></returns>
        public IEnumerable<Message> GetAllByBoat(int boat_id)
        {
            using (TripleBDbContext db = new TripleBDbContext())
            {
                return db.Messages.Where(x => x.BoatId == boat_id && x.Type.Equals("recall")).ToList();
            }
        }

        /// <summary>
        /// Получить все входящие заявки для пользователя
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public IEnumerable<Message> GetAllInbox(int user_id)
        {
            using (TripleBDbContext db = new TripleBDbContext())
            {
                return db.Messages.Where(x => x.ToId == user_id).ToList();
            }
        }

        /// <summary>
        /// Получить все исходящие заявки от пользователя
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public IEnumerable<Message> GetAllOutbox(int user_id)
        {
            using (TripleBDbContext db = new TripleBDbContext())
            {
                return db.Messages.Where(x => x.FromId == user_id).ToList();
            }
        }

        /// <summary>
        /// Получение всех заявок из БД
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Message> Read()
        {
            using (TripleBDbContext db = new TripleBDbContext())
            {
                return db.Messages.ToList();
            }
        }

        /// <summary>
        /// Обновление данных заявки в БД
        /// </summary>
        /// <param name="recall"></param>
        public void Update(Message recall)
        {
            using (TripleBDbContext db = new TripleBDbContext())
            {
                if (recall != null)
                {
                    db.Messages.Update(recall);
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
                Message recall = db.Messages.FirstOrDefault(x => x.Id == id);
                if (recall != null)
                {
                    db.Messages.Remove(recall);
                    db.SaveChanges();
                }
            }
        }
    }
}
