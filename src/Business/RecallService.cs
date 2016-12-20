using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DB.Repositories;
using Models;
using ViewModels;

namespace Business
{
    public class RecallService
    {
        private RecallRepository rec_repository;
        private RentRepository ren_repository;

        public RecallService()
        {
            rec_repository = new RecallRepository();
            ren_repository = new RentRepository();
        }

        public List<RecallCollectionViewModel> GetOutbox(int account_id)
        {
            return null;
        }

        public List<RecallCollectionViewModel> GetInbox(int account_id)
        {
            return null;
        }

        public int AddRecall(RecallViewModel data)
        {
            return 0;
        }

        public int DeleteRecall(int recall_id)
        {
            return 0;
        }
    }
}
