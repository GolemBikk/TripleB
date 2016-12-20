using Models;
using System.Collections.Generic;
using System.Linq;

namespace DB.Repositories
{
    public class TextBlockRepository
    {
        /// <summary>
        /// Добавление текстового блока в БД
        /// </summary>
        /// <param name="textblock"></param>
        public void Create(TextBlock textblock)
        {
            using (TripleBDbContext db = new TripleBDbContext())
            {
                if (textblock != null)
                {
                    db.NewsTexts.Add(textblock);
                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Получение текстового блока из БД по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TextBlock Read(int id)
        {
            using (TripleBDbContext db = new TripleBDbContext())
            {
                return db.NewsTexts.FirstOrDefault(x => x.Id == id);
            }
        }

        /// <summary>
        /// Получение всех текстовых блоков из БД
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TextBlock> GetByOwnerId(int owner_id)
        {
            using (TripleBDbContext db = new TripleBDbContext())
            {
                return db.NewsTexts.Where(x => x.OwnerId == owner_id).ToList();
            }
        }

        /// <summary>
        /// Обновление данных текстового блока в БД
        /// </summary>
        /// <param name="textblock"></param>
        public void Update(TextBlock textblock)
        {
            using (TripleBDbContext db = new TripleBDbContext())
            {
                if (textblock != null)
                {
                    db.NewsTexts.Update(textblock);
                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Удаление текстового блока из БД
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            using (TripleBDbContext db = new TripleBDbContext())
            {
                TextBlock textblock = db.NewsTexts.FirstOrDefault(x => x.Id == id);
                if (textblock != null)
                {
                    db.NewsTexts.Remove(textblock);
                    db.SaveChanges();
                }
            }
        }

        public void DeleteByOwnerId(int owner_id)
        {
            using (TripleBDbContext db = new TripleBDbContext())
            {
                foreach (TextBlock textblock in db.NewsTexts.Where(x => x.OwnerId == owner_id))
                {
                    if (textblock != null)
                    {
                        db.NewsTexts.Remove(textblock);                        
                    }
                }
                db.SaveChanges();
            }
        }
    }
}
