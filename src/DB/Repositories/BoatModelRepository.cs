using Models;
using System.Collections.Generic;
using System.Linq;

namespace DB.Repositories
{
    public class BoatModelRepository
    {
        /// <summary>
        /// Добавление модели лодки в БД
        /// </summary>
        /// <param name="boatmodel"></param>
        public void Create(BoatModel boatmodel)
        {
            using (TripleBDbContext db = new TripleBDbContext())
            {
                if (boatmodel != null)
                {
                    db.BoatModels.Add(boatmodel);
                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Получение модели лодки из БД по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BoatModel GetById(int id)
        {
            using (TripleBDbContext db = new TripleBDbContext())
            {
                return db.BoatModels.FirstOrDefault(x => x.Id == id);
            }
        }

        /// <summary>
        /// Получение модели лодки из БД по названию
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public BoatModel GetByName(string name)
        {
            using (TripleBDbContext db = new TripleBDbContext())
            {
                return db.BoatModels.FirstOrDefault(x => x.Name == name);
            }
        }

        /// <summary>
        /// Получение всех моделей лодок из БД
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BoatModel> Read()
        {
            using (TripleBDbContext db = new TripleBDbContext())
            {
                return db.BoatModels.ToList();
            }
        }

        /// <summary>
        /// Обновление данных модели лодки в БД
        /// </summary>
        /// <param name="boatmodel"></param>
        public void Update(BoatModel boatmodel)
        {
            using (TripleBDbContext db = new TripleBDbContext())
            {
                if (boatmodel != null)
                {
                    db.BoatModels.Update(boatmodel);
                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Удаление модели лодки из БД
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            using (TripleBDbContext db = new TripleBDbContext())
            {
                BoatModel boatmodel = db.BoatModels.FirstOrDefault(x => x.Id == id);
                if (boatmodel != null)
                {
                    db.BoatModels.Remove(boatmodel);
                    db.SaveChanges();
                }
            }
        }
    }
}
