using DataServices.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataServices.Interfaces
{
    public interface IProductRepository
    {
        Task<ICollection<Product>> RetrieveAll();
        Task<Product> RetrieveById(int id);
        Task Create(Product product);
        Task Update(Product product);
        Task Delete(int id);
    }
}
