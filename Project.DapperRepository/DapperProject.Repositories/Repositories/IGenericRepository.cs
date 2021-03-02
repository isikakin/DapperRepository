using System.Collections.Generic;
using System.Threading.Tasks;

namespace DapperProject.Repositories.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task Insert(T entity);
        Task<int> InsertRange(IEnumerable<T> entities);
        Task Update(T entity);
        Task Delete(int id);
    }
}
