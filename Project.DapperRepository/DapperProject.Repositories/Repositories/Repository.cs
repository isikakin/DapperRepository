using Dapper;
using DapperProject.Commands.Queries;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DapperProject.Repositories.Repositories
{
    public class Repository<T> : IGenericRepository<T> where T : class
    {
        private readonly IDbConnection _connection;

        private readonly QueryFactory _queryFactory;

        public Repository(IDbConnection connection)
        {
            _connection = connection;
            _queryFactory = new QueryFactory();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _connection.QueryAsync<T>(_queryFactory.GetCommand(new SelectCommand<T>()));
        }
        public async Task<T> Get(int id)
        {
            var result = await _connection.QuerySingleOrDefaultAsync<T>(_queryFactory.GetCommand(new SelectByIdCommand<T>()), new { Id = id });
            return result;
        }
        public async Task Insert(T entity)
        {
            string insertQuery = _queryFactory.GetCommand(new InsertCommand<T>());
            await _connection.ExecuteAsync(insertQuery, entity);
        }
        public async Task<int> InsertRange(IEnumerable<T> entities)
        {
            int inserted = 0;
            string query = _queryFactory.GetCommand(new InsertCommand<T>());
            inserted += await _connection.ExecuteAsync(query, entities);

            return inserted;
        }
        public async Task Update(T entity)
        {
            string updateQuery = _queryFactory.GetCommand(new UpdateCommand<T>());

            await _connection.ExecuteAsync(updateQuery, entity);
        }
        public async Task Delete(int id)
        {
            await _connection.ExecuteAsync(_queryFactory.GetCommand(new DeleteCommand<T>()), new { Id = id });
        }
    }
}
