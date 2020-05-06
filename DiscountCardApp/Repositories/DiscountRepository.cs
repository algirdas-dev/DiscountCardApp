using Dapper;
using DiscountCardApp.DB;
using DiscountCardApp.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DiscountCardApp.Repositories
{
    public class DiscountRepository : DiscountRepositoryInterface
    {
        private readonly IDbConnection _connection;
        public DiscountRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public List<string> GetList(string code)
        {
            string sql = "select p.Code from Products p " +
                "join DiscountProducts dp on p.productId = dp.productId " +
                "join Discounts c on c.DiscountId = dp.DiscountId " +
                "where c.Code = @code ";
            return _connection.Query<string>(sql, new { code }).ToList();
        }
    }
}
