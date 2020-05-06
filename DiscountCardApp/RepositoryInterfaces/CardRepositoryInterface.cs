using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscountCardApp.RepositoryInterfaces
{
    public interface CardRepositoryInterface
    {
        public List<string> GetList(string cardNo);
    }
}
