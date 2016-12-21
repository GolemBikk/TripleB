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
        private MessageRepository m_repository;
        private RentRepository r_repository;

        public MessageService()
        {
            m_repository = new MessageRepository();
            r_repository = new RentRepository();
        }

        public List<MessageCollectionViewModel> GetOutbox(int account_id)
        {
            return null;
        }

        public List<MessageCollectionViewModel> GetInbox(int account_id)
        {
            return null;
        }

        public int AddRecall(MessageViewModel data)
        {
            return 0;
        }

        public int DeleteRecall(int recall_id)
        {
            return 0;
        }
    }
}
