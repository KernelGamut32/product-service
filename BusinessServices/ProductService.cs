using BusinessServices.Interfaces;
using DataServices.Interfaces;
using DataServices.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessServices
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<ICollection<Product>> RetrieveAll()
        {
            return await productRepository.RetrieveAll();
        }

        public async Task<Product> RetrieveById(int id)
        {
            return await productRepository.RetrieveById(id);
        }

        public async Task Create(Product product)
        {
            await productRepository.Create(product);
        }

        public async Task Update(Product product)
        {
            await productRepository.Update(product);
        }

        public async Task Delete(int id)
        {
            await productRepository.Delete(id);
        }
    }
}
