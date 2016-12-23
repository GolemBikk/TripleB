using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DB.Repositories;
using Models;
using ViewModels;

namespace Business
{
    public class MessageService
    {
        private AccountRepository a_repository;
        private BoatRepository b_repository;
        private BoatModelRepository bm_repository;
        private MessageRepository m_repository;
        private RentRepository r_repository;

        public MessageService()
        {
            a_repository = new AccountRepository();
            b_repository = new BoatRepository();
            bm_repository = new BoatModelRepository();
            m_repository = new MessageRepository();
            r_repository = new RentRepository();
        }

        public MessageViewModel GetMessageInfo(int message_id)
        {
            Message message = m_repository.GetById(message_id);
            MessageViewModel result = new MessageViewModel
            {
                Id = message.Id,
                Login = a_repository.GetById(message.FromId).Login,
                Text = message.Text,
                Date = message.Date
            };
            return result;
        }

        /// <summary>
        /// Получить комментарии к лодке
        /// </summary>
        /// <param name="boat_id"></param>
        /// <returns></returns>
        public List<MessageViewModel> GetComments(int boat_id)
        {
            List<Message> comments = m_repository.GetAllByBoat(boat_id).ToList();
            List<MessageViewModel> result = new List<MessageViewModel>();
            foreach (Message item in comments)
            {
                string login = a_repository.GetById(item.FromId).Login;
                result.Add(new MessageViewModel
                {
                    Id = item.Id,
                    ClientId = item.FromId,
                    Login = login,
                    Text = item.Text,
                    Date = item.Date
                });
            }
            return result;
        }

        /// <summary>
        /// Получить входящие заявки для пользователя
        /// </summary>
        /// <param name="account_id"></param>
        /// <returns></returns>
        public List<MessageViewModel> GetOutbox(int account_id)
        {
            List<Message> comments = m_repository.GetAllOutbox(account_id).ToList();
            List<MessageViewModel> result = new List<MessageViewModel>();
            foreach (Message item in comments)
            {
                string login = a_repository.GetById(item.ToId).Login;
                int model_id = b_repository.Boat_GetById(item.BoatId).ModelId;
                string model = bm_repository.GetById(model_id).Name;
                result.Add(new MessageViewModel
                {
                    Id = item.Id,
                    Login = login,
                    BoatModel = model,
                    Text = item.Text,
                    Date = item.Date
                });
            }
            return result;
        }

        /// <summary>
        /// Получить исходящие заявки от пользователя
        /// </summary>
        /// <param name="account_id"></param>
        /// <returns></returns>
        public List<MessageViewModel> GetInbox(int account_id)
        {
            List<Message> comments = m_repository.GetAllOutbox(account_id).ToList();
            List<MessageViewModel> result = new List<MessageViewModel>();
            foreach (Message item in comments)
            {
                string login = a_repository.GetById(item.FromId).Login;
                int model_id = b_repository.Boat_GetById(item.BoatId).ModelId;
                string model = bm_repository.GetById(model_id).Name;
                result.Add(new MessageViewModel
                {
                    Id = item.Id,
                    Login = login,
                    BoatId = item.BoatId,
                    BoatModel = model,
                    Text = item.Text,
                    Date = item.Date
                });
            }
            return result;
        }

        /// <summary>
        /// Добавление комментария к лодке
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int AddComment(MessageViewModel data)
        {
            try
            {
                Message new_message = new Message
                {
                    BoatId = data.BoatId,
                    FromId = data.ClientId,
                    ToId = data.CustomerId,
                    Text = data.Text,
                    Date = DateTime.Today,
                    Type = "comment"
                };
                m_repository.Create(new_message);
                return 0;
            }
            catch
            {
                return 1;
            }
        }

        /// <summary>
        /// Добавление заявки
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int AddRecall(MessageViewModel data)
        {
            try
            {
                Message new_message = new Message
                {
                    BoatId = data.BoatId,
                    FromId = data.ClientId,
                    ToId = data.CustomerId,
                    Text = data.Text,
                    Date = DateTime.Today,
                    Type = "recall"
                };
                m_repository.Create(new_message);
                return 0;
            }
            catch
            {
                return 1;
            }
        }

        /// <summary>
        /// Добавление жалобы
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int AddComplaint(int message_id)
        {
            try
            {
                Message message = m_repository.GetById(message_id);
                Account account = a_repository.GetById(message.FromId);
                string text = String.Format("Прошу заблокировать пользователя {0} в связи с недопустимым содержимым комментария/заявки", account.Login);
                Message new_message = new Message
                {
                    BoatId = message_id,
                    Text = text,
                    Date = DateTime.Today,
                    Type = "complaint"
                };
                m_repository.Create(new_message);
                return 0;
            }
            catch
            {
                return 1;
            }
        }

        /// <summary>
        /// Удаление сообщения
        /// </summary>
        /// <param name="message_id"></param>
        public void DeleteMessage(int message_id)
        {
            m_repository.Delete(message_id);
        }
    }
}
