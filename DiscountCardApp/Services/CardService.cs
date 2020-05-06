using DiscountCardApp.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscountCardApp.Services
{
    public class CardService
    {
        private CardRepositoryInterface _repository;
        public CardService(CardRepositoryInterface repository) {
            _repository = repository;
        }
        public List<string> GetList(string cardNo)
        {
            return _repository.GetList(cardNo);
        }
    }
}
