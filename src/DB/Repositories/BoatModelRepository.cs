using Models;
using System.Collections.Generic;
using System.Linq;

namespace DB.Repositories
{
    public class BoatModelRepository
    {
        private TripleBDbContext db;

        public BoatModelRepository(TripleBDbContext db)
        {
            this.db = db;
        }


        /// <summary>
        /// Добавление модели лодки в БД
        /// </summary>
        /// <param name="boatmodel"></param>
        public void Create(BoatModel boatmodel)
        {
            if (boatmodel != null)
            {
                db.BoatModels.Add(boatmodel);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Получение модели лодки из БД по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BoatModel Read(int id)
        {
            return db.BoatModels.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Получение всех моделей лодок из БД
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BoatModel> Read()
        {
            return db.BoatModels.ToList();
        }

        /// <summary>
        /// Обновление данных модели лодки в БД
        /// </summary>
        /// <param name="boatmodel"></param>
        public void Update(BoatModel boatmodel)
        {
            if (boatmodel != null)
            {
                db.BoatModels.Update(boatmodel);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Удаление модели лодки из БД
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
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
