using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace SSDLDotNetCore.Shared
{
    public class DapperService
    {
        private readonly string _connectionString;

        public DapperService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<B> Query<B>(string query, object? param = null)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            //if (param is not null)
            //{
            //    var lst = db.Query<B>(query, param).ToList();
            //}
            //else
            //{
            //    var lst = db.Query<B>(query).ToList();
            //}
            var lst = db.Query<B>(query, param).ToList();
            return lst;
        }

        public B QueryFirstOrDefault<B>(string query, object? param = null)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var item = db.Query<B>(query, param).FirstOrDefault();
            return item!;
        }

        public int Execute(string query, object? param = null)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var result = db.Execute(query, param);
            return result;
        }
    }
}
