using Models;
using System.Collections.Generic;
using System.Linq;

namespace DB.Repositories
{
    public class NewsRepository
    {
        /// <summary>
        /// Добавление новости в БД
        /// </summary>
        /// <param name="news"></param>
        public int Create(News news)
        {
            using (TripleBDbContext db = new TripleBDbContext())
            {
                if (news != null)
                {
                    db.News.Add(news);
                    db.SaveChanges();
                }
            }
            return news.Id;
        }

        /// <summary>
        /// Получение новости из БД по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public News GetById(int id)
        {
            using (TripleBDbContext db = new TripleBDbContext())
            {
                return db.News.FirstOrDefault(x => x.Id == id);
            }
        }

        /// <summary>
        /// Получение всех новостей из БД
        /// </summary>
        /// <returns></returns>
        public IEnumerable<News> GetAll()
        {
            using (TripleBDbContext db = new TripleBDbContext())
            {
                return db.News.ToList();
            }
        }

        /// <summary>
        /// Обновление данных новости в БД
        /// </summary>
        /// <param name="news"></param>
        public void Update(News news)
        {
            using (TripleBDbContext db = new TripleBDbContext())
            {
                var result = db.News.FirstOrDefault(x => x.Id == news.Id);


                if (news != null)
                {
                    result.Preview = news.Preview;
                    result.Title = news.Title;
                    result.Date = news.Date;
                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Удаление новости из БД
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            using (TripleBDbContext db = new TripleBDbContext())
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
}
