using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DB.Repositories;
using Models;
using ViewModels;

namespace Business
{
    public class BoatService
    {
        private BoatModelRepository bm_repository;
        private BoatRepository b_repository;
        private ImageRepository i_repository;
        private RentRepository r_repository;

        public BoatService()
        {
            bm_repository = new BoatModelRepository();
            b_repository = new BoatRepository();
            i_repository = new ImageRepository();
            r_repository = new RentRepository();
        }

        /// <summary>
        /// Добавление новой лодки
        /// </summary>
        /// <param name="data"></param>
        /// <param name="images"></param>
        /// <returns></returns>
        public int AddBoat(BoatViewModel data)
        {
            try
            {               
                if (bm_repository.GetByName(data.BoatModel) == null)
                {
                    BoatModel model = new BoatModel
                    {
                        Name = data.BoatModel,
                        Length = data.Lenght,
                        Width = data.Width,
                        Displacement = data.Displacement,
                        ManufacturerName = data.ManufacturerName
                    };
                    bm_repository.Create(model);
                }
                int model_id = bm_repository.GetByName(data.BoatModel).Id;
                Boat boat = new Boat
                {
                    BoatType = data.Type,
                    Speed = data.Speed,
                    Cost = data.Cost,
                    Description = data.Description,
                    Kind = data.Kind,
                    Status = true,
                    OwnerId = data.Owner,
                    ModelId = model_id
                };
                int boat_id = b_repository.Boat_Create(boat);
                if(data.Images != null && data.Images.Count > 0)
                {
                    foreach (byte[] content in data.Images)
                    {
                        Image image = new Image
                        {
                            Content = content,
                            OwnerId = boat_id
                        };
                        i_repository.Create(image);
                    }
                }
                return 0;
            }
            catch
            {
                return 1;
            }
        }

        /// <summary>
        /// Редактирование лодки
        /// </summary>
        /// <param name="data"></param>
        /// <param name="images"></param>
        /// <returns></returns>
        public int EditBoat(BoatViewModel data)
        {
            try
            {
                Boat boat = new Boat
                {
                    Id = data.ID,
                    BoatType = data.Type,
                    Speed = data.Speed,
                    Cost = data.Cost,
                    Description = data.Description,
                    Kind = data.Kind,
                    Status = true,
                };
                b_repository.Boat_Update(boat);
                return 0;
            }
            catch
            {
                return 1;
            }
        }

        /// <summary>
        /// Удаление лодки из БД
        /// </summary>
        /// <param name="boat_id"></param>
        /// <returns></returns>
        public int DeleteBoat(int boat_id)
        {
            try
            {
                b_repository.Boat_Delete(boat_id);
                i_repository.DeleteByOwnerId(boat_id);
                return 0;
            }
            catch
            {
                return 1;
            }
        }

        /// <summary>
        /// Получение полной информации по лодке
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BoatViewModel GetBoatInfo(int id)
        {
            Boat b_result = b_repository.Boat_GetById(id);
            BoatModel bm_result = bm_repository.GetById(b_result.ModelId);
            List<byte[]> images = null;
            List<Image> i_result = i_repository.GetAllByOwnerId(b_result.Id).ToList();
            if (i_result != null)
            {
                images = new List<byte[]>();
                foreach (Image image in i_result)
                {
                    images.Add(image.Content);
                }
            }
            List<RentViewModel> rents = null;
            List<Rent> r_result = r_repository.GetByOwnerId(b_result.Id).ToList();
            if (r_result != null)
            {
                rents = new List<RentViewModel>();
                foreach (Rent rent in r_result)
                {
                    rents.Add(new RentViewModel { StatusFrom = rent.From, StatusTo = rent.To});
                }
            }
            BoatViewModel boat = new BoatViewModel
            {
                ID = b_result.Id,
                Type = b_result.BoatType,
                Speed = b_result.Speed,
                Cost = b_result.Cost,
                Description = b_result.Description,
                Kind = b_result.Kind,
                Status = b_result.Status,
                Owner = b_result.OwnerId,
                BoatModel = bm_result.Name,
                Lenght = bm_result.Length,
                Width = bm_result.Width,
                Displacement = bm_result.Displacement,
                ManufacturerName = bm_result.ManufacturerName,
                Images = images,
                Rents = rents
            };           
            return boat;
        }

        /// <summary>
        /// Получение информации о имеющися лодках
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public List<BoatCollectionViewModel> GetAllBoat(PageInfo info, string kind)
        {
            List<BoatCollectionViewModel> result = new List<BoatCollectionViewModel>();
            foreach (Boat item in b_repository.Boat_GetAll(kind))
            {
                result.Add(new BoatCollectionViewModel
                {
                    Id = item.Id,
                    BoatModel = bm_repository.GetById(item.ModelId).Name,
                    Image = i_repository.GetAllByOwnerId(item.Id).First().Content,
                    Discription = item.Description
                });
            }
            if (info != null && (result.Count > info.PageSize && result.Count < info.PageSize * (info.PageNumber - 1)))
            {
                int item_num = 1,
                    bottom_boart = info.PageSize * (info.PageNumber - 1),
                    top_boart = info.PageSize * info.PageNumber;
                List<BoatCollectionViewModel> result_page = new List<BoatCollectionViewModel>();
                foreach (BoatCollectionViewModel item in result)
                {
                    if (item_num > bottom_boart && item_num <= top_boart)
                    {
                        result_page.Add(item);
                    }
                    item_num++;
                }
                return result_page;
            }
            return result;            
        }

        /// <summary>
        /// Получить все предложения пользователя
        /// </summary>
        /// <param name="info"></param>
        /// <param name="owner_id"></param>
        /// <returns></returns>
        public List<BoatCollectionViewModel> GetUsersBoat(PageInfo info, int owner_id)
        {
            List<BoatCollectionViewModel> result = new List<BoatCollectionViewModel>();
            foreach (Boat item in b_repository.Boat_GetByUserId(owner_id))
            {
                string model_name = bm_repository.GetById(item.ModelId).Name;
                var images = i_repository.GetAllByOwnerId(item.Id);
                result.Add(new BoatCollectionViewModel
                {
                    Id = item.Id,
                    BoatModel = model_name,
                    Image = images.First().Content,
                    Discription = item.Description
                });
            }
            if (info != null && (result.Count > info.PageSize && result.Count < info.PageSize * (info.PageNumber - 1)))
            {
                int item_num = 1,
                    bottom_boart = info.PageSize * (info.PageNumber - 1),
                    top_boart = info.PageSize * info.PageNumber;
                List<BoatCollectionViewModel> result_page = new List<BoatCollectionViewModel>();
                foreach (BoatCollectionViewModel item in result)
                {
                    if (item_num > bottom_boart && item_num <= top_boart)
                    {
                        result_page.Add(item);
                    }
                    item_num++;
                }
                return result_page;
            }
            return result;
        }

        /// <summary>
        /// Покупка (аренда) лодки
        /// </summary>
        /// <returns></returns>
        public int BuyOrRentBoat(int boat_id)
        {
            try
            {
                Boat boat = b_repository.Boat_GetById(boat_id);
                boat.Status = false;
                b_repository.Boat_Update(boat);
                return 0;
            }
            catch
            {
                return 1;
            }
        }
    }
}
