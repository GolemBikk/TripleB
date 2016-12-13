using Models;
using System.Collections.Generic;
using System.Linq;

namespace DB.Repositories
{
    public class TextBlockRepository
    {
        private TripleBDbContext db;

        public TextBlockRepository(TripleBDbContext db)
        {
            this.db = db;
        }

        /// <summary>
        /// Добавление текстового блока в БД
        /// </summary>
        /// <param name="textblock"></param>
        public void Create(TextBlock textblock)
        {
            if (textblock != null)
            {
                db.NewsTexts.Add(textblock);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Получение текстового блока из БД по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TextBlock Read(int id)
        {
            return db.NewsTexts.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Получение всех текстовых блоков из БД
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TextBlock> Read()
        {
            return db.NewsTexts.ToList();
        }

        /// <summary>
        /// Обновление данных текстового блока в БД
        /// </summary>
        /// <param name="textblock"></param>
        public void Update(TextBlock textblock)
        {
            if (textblock != null)
            {
                db.NewsTexts.Update(textblock);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Удаление текстового блока из БД
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            TextBlock textblock = db.NewsTexts.FirstOrDefault(x => x.Id == id);
            if (textblock != null)
            {
                db.NewsTexts.Remove(textblock);
                db.SaveChanges();
            }
        }
    }
}
