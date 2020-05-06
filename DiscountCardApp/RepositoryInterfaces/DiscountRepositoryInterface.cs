using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscountCardApp.RepositoryInterfaces
{
    public interface DiscountRepositoryInterface
    {
        public List<string> GetList(string code);
    }
}
