using Models;
using System.Collections.Generic;
using System.Linq;

namespace DB.Repositories
{
    public class ImageRepository
    {
        private TripleBDbContext db;

        public ImageRepository(TripleBDbContext db)
        {
            this.db = db;
        }

        /// <summary>
        /// Добавление изображения в БД
        /// </summary>
        /// <param name="image"></param>
        public void Create(Image image)
        {
            if (image != null)
            {
                db.Images.Add(image);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Получение изображения из БД по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Image Read(int id)
        {
            return db.Images.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Получение всех изображений из БД
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Image> Read()
        {
            return db.Images.ToList();
        }

        /// <summary>
        /// Обновление данных изображения в БД
        /// </summary>
        /// <param name="image"></param>
        public void Update(Image image)
        {
            if (image != null)
            {
                db.Images.Update(image);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Удаление изображения из БД
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            Image image = db.Images.FirstOrDefault(x => x.Id == id);
            if (image != null)
            {
                db.Images.Remove(image);
                db.SaveChanges();
            }
        }
    }
}
