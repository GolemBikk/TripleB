using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DB.Repositories;
using Models;
using ViewModels;

namespace Business
{
    public class NewsService
    {
        private NewsRepository n_repository;
        private TextBlockRepository t_repository;
        private ImageRepository i_repository;

        public NewsService()
        {
            n_repository = new NewsRepository();
            t_repository = new TextBlockRepository();
            i_repository = new ImageRepository();
        }

        /// <summary>
        /// Получение полной новости
        /// </summary>
        /// <param name="news_id"></param>
        /// <returns></returns>
        public NewsViewModel GetNewsInfo(int news_id)
        {
            News n_result = n_repository.GetById(news_id);
            List<string> textbloks = null;
            List<TextBlock> t_result = t_repository.GetByOwnerId(news_id).ToList();
            if (t_result != null)
            {
                textbloks = new List<string>();
                foreach (TextBlock textblock in t_result)
                {
                    textbloks.Add(textblock.Text);
                }
            }
            List<byte[]> images = null;
            List<Image> i_result = i_repository.GetAllByOwnerId(news_id).ToList();
            if (i_result != null)
            {
                images = new List<byte[]>();
                foreach (Image image in i_result)
                {
                    images.Add(image.Content);
                }
            }
            NewsViewModel news = new NewsViewModel
            {
                Id = n_result.Id,
                Date = n_result.Date,
                Title = n_result.Title,
                Discription = n_result.Preview,
                Images = images
            };
            foreach (String item in textbloks)
            {
                news.Text += item + "\r\n";
            }
            return news;
        }

        /// <summary>
        /// Получение списка анонсов новостей
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public List<NewsCollectionViewModel> GetAllNews(PageInfo info)
        {
            List<News> n_result = n_repository.GetAll().ToList();
            
            List<NewsCollectionViewModel> result = new List<NewsCollectionViewModel>();
            foreach (News item in n_result)
            {
                Image image = i_repository.GetFirstByOwnerId(item.Id);

                if (image != null)
                {
                    result.Add(new NewsCollectionViewModel
                    {
                        Id = item.Id,
                        Title = item.Title,
                        Discription = item.Preview,
                        Date = item.Date,
                        Image = image.Content
                    });
                }
                else
                {
                    result.Add(new NewsCollectionViewModel
                    {
                        Id = item.Id,
                        Title = item.Title,
                        Discription = item.Preview,
                        Date = item.Date
                    });
                }

            }
            if (info != null && (result.Count > info.PageSize && result.Count < info.PageSize * (info.PageNumber - 1)))
            {
                int item_num = 1,
                    bottom_boart = info.PageSize * (info.PageNumber - 1),
                    top_boart = info.PageSize * info.PageNumber;
                List<NewsCollectionViewModel> result_page = new List<NewsCollectionViewModel>();
                foreach (NewsCollectionViewModel item in result)
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
        /// Добавление новости
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int AddNews(NewsViewModel data)
        {
            try
            {
                int news_id = n_repository.Create(new News
                {
                    Title = data.Title,
                    Preview = data.Discription,
                    Date = DateTime.Today
                });
                int i = 0;
                foreach (string item in data.Text.Split(new char[] { '\r','\n' }))
                {
                    t_repository.Create(new TextBlock
                    {
                        Text = item,
                        Rank = i,
                        OwnerId = news_id
                    });
                    i++;
                }
                if (data.Images != null && data.Images.Count > 0)
                {
                    foreach (byte[] item in data.Images)
                    {
                        i_repository.Create(new Image
                        {
                            Content = item,
                            OwnerId = news_id
                        });
                        i++;
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
        /// Редактирование новости
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int EditNews(NewsViewModel data)
        {
            try
            {
                n_repository.Update(new News
                {
                    Id = data.Id,
                    Title = data.Title,
                    Preview = data.Discription,
                    Date = DateTime.Today
                });
                int i = 0;
                t_repository.DeleteByOwnerId(data.Id);
                foreach (string item in data.Text.Split(new char[] { '\r', '\n'}))
                {
                    t_repository.Create(new TextBlock
                    {
                        Text = item,
                        Rank = i,
                        OwnerId = data.Id
                    });
                    i++;
                }
                return 0;
            }
            catch
            {
                return 1;
            }
        }

        /// <summary>
        /// Удаление новости
        /// </summary>
        /// <param name="news_id"></param>
        /// <returns></returns>
        public int DeleteNews(int news_id)
        {
            try
            {
                n_repository.Delete(news_id);
                t_repository.DeleteByOwnerId(news_id);
                i_repository.DeleteByOwnerId(news_id);
                return 0;
            }
            catch
            {
                return 1;
            }
        }
    }
}
