using Models;
using System.Collections.Generic;
using System.Linq;

namespace DB.Repositories
{
    public class NewsRepository
    {
        private TripleBDbContext db;

        public NewsRepository(TripleBDbContext db)
        {
            this.db = db;
        }

        /// <summary>
        /// Добавление новости в БД
        /// </summary>
        /// <param name="news"></param>
        public void Create(News news)
        {
            if (news != null)
            {
                db.News.Add(news);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Получение новости из БД по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public News Read(int id)
        {
            return db.News.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Получение всех новостей из БД
        /// </summary>
        /// <returns></returns>
        public IEnumerable<News> Read()
        {
            return db.News.ToList();
        }

        /// <summary>
        /// Обновление данных новости в БД
        /// </summary>
        /// <param name="news"></param>
        public void Update(News news)
        {
            if (news != null)
            {
                db.News.Update(news);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Удаление новости из БД
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            News news = db.News.FirstOrDefault(x => x.Id == id);
            if (news != null)
            {
                db.News.Remove(news);
                db.SaveChanges();
            }
        }
    }
}
