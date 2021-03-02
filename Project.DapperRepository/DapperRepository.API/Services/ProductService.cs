using DapperProject.Entities.Entities;
using DapperProject.Repositories.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DapperRepository.API.Services
{
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Product> _repository;

        public ProductService(IGenericRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _repository.GetAll();
        }
        public async Task<Product> Get(int id)
        {
            return await _repository.Get(id);
        }
        public async Task Insert(Product product)
        {
            await _repository.Insert(product);
        }
        public async Task<int> InsertRange(IEnumerable<Product> products)
        {
            return await _repository.InsertRange(products);
        }
        public async Task Update(Product product)
        {
            await _repository.Update(product);
        }
        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }
    }
}
