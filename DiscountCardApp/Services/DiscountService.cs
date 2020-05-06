using DiscountCardApp.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscountCardApp.Services
{
    public class DiscountService
    {
        private DiscountRepositoryInterface _repository;
        public DiscountService(DiscountRepositoryInterface repository) {
            _repository = repository;
        }

        public List<string> GetList(string code) {
            return _repository.GetList(code);
        }
    }
}
