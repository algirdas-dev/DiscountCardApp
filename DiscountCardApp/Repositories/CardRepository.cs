using Dapper;
using DiscountCardApp.RepositoryInterfaces;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DiscountCardApp.Repositories
{
    public class CardRepository : CardRepositoryInterface
    {
        private readonly IDbConnection _connection;
        public CardRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public List<string> GetList(string cardNo) {
            string sql = "select p.Code from Products p " +
                "join CardProducts cp on p.productId = cp.productId " +
                "join Cards c on c.CardId = cp.CardId " +
                "where c.Code = @cardNo ";
            return _connection.Query<string>(sql, new { cardNo }).ToList();
        }
    }
}
