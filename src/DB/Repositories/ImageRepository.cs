using Models;
using System.Collections.Generic;
using System.Linq;

namespace DB.Repositories
{
    public class ImageRepository
    {
        /// <summary>
        /// Добавление изображения в БД
        /// </summary>
        /// <param name="image"></param>
        public void Create(Image image)
        {
            using (TripleBDbContext db = new TripleBDbContext())
            {
                if (image != null)
                {
                    db.Images.Add(image);
                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Получение изображения из БД по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Image GetById(int id)
        {
            using (TripleBDbContext db = new TripleBDbContext())
            {
                return db.Images.FirstOrDefault(x => x.Id == id);
            }
        }

        /// <summary>
        /// Получение изображения из БД по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Image GetFirstByOwnerId(int owner_id)
        {
            using (TripleBDbContext db = new TripleBDbContext())
            {
                return db.Images.Where(x => x.OwnerId == owner_id).FirstOrDefault();
            }
        }

        /// <summary>
        /// Получение всех изображений из БД
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Image> GetAllByOwnerId(int owner_id)
        {
            using (TripleBDbContext db = new TripleBDbContext())
            {
                return db.Images.Where(x => x.OwnerId == owner_id).ToList();
            }
        }

        /// <summary>
        /// Обновление данных изображения в БД
        /// </summary>
        /// <param name="image"></param>
        public void Update(Image image)
        {
            using (TripleBDbContext db = new TripleBDbContext())
            {
                if (image != null)
                {
                    db.Images.Update(image);
                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Удаление изображения из БД
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            using (TripleBDbContext db = new TripleBDbContext())
            {
                Image image = db.Images.FirstOrDefault(x => x.Id == id);
                if (image != null)
                {
                    db.Images.Remove(image);
                    db.SaveChanges();
                }
            }
        }

        public void DeleteByOwnerId(int owner_id)
        {
            using (TripleBDbContext db = new TripleBDbContext())
            {
                foreach (Image image in db.Images.Where(x => x.OwnerId == owner_id))
                {
                    if (image != null)
                    {
                        db.Images.Remove(image);
                    }
                }
                db.SaveChanges();
            }
        }
    }
}
