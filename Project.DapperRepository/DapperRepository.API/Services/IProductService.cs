using DapperProject.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DapperRepository.API.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> Get(int id);
        Task Insert(Product product);
        Task<int> InsertRange(IEnumerable<Product> products);
        Task Update(Product product);
        Task Delete(int id);
    }
}
