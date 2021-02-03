using DataServices.Context;
using DataServices.Interfaces;
using DataServices.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataServices.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext context;

        public ProductRepository(ProductDbContext context)
        {
            this.context = context;
        }

        public async Task<ICollection<Product>> RetrieveAll()
        {
            return await context.Product.ToListAsync();
        }

        public async Task<Product> RetrieveById(int id)
        {
            return await context.Product.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task Create(Product product)
        {
            context.Product.Add(product);
            await context.SaveChangesAsync();
        }

        public async Task Update(Product product)
        {
            var productToEdit = await RetrieveById(product.Id);
            productToEdit.CatalogNumber = product.CatalogNumber;
            productToEdit.Description = product.Description;
            productToEdit.UnitCost = product.UnitCost;
            productToEdit.QuantityInStock = product.QuantityInStock;
            productToEdit.InventoryStatus = product.InventoryStatus;
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var productToDelete = await RetrieveById(id);
            context.Product.Remove(productToDelete);
            await context.SaveChangesAsync();
        }
    }
}
