using Dapper;
using System.Data;
using System.Data.SQLite;

namespace SocialNetwork.DAL.Repositories
{
    public class BaseRepository
    {
        /// <summary>
        /// Returns single selection for DB sql-query with parameters 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        protected T QueryFirstOrDefault<T>(string sql, object parameters = null)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                return connection.QueryFirstOrDefault<T>(sql, parameters);
            }
        }

        /// <summary>
        /// Returns multiple selection for DB sql-query with parameters 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        protected List<T> Query<T>(string sql, object parameters = null)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                return connection.Query<T>(sql, parameters).ToList();
            }
        }

        /// <summary>
        /// Execute DB operations: insert, update, delete
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        protected int Execute(string sql, object parameters = null)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                return connection.Execute(sql, parameters);
            }
        }

        /// <summary>
        /// Set DB connection
        /// </summary>
        /// <returns></returns>
        private IDbConnection CreateConnection()
        {
            return new SQLiteConnection("Data Source=DAL/DB/social_network_bd.db"); // ; Version = 3
        }
    }
}