using Microsoft.EntityFrameworkCore;
using ProductMicroservice.DBContexts;
using ProductMicroservice.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProductMicroservice.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _dbContext;

        public ProductRepository(ProductContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Product> GetProducts() =>
            _dbContext.Products.ToList();

        public Product GetProductById(int productId) =>
            _dbContext.Products.Find(productId);

        public void InsertProduct(Product product)
        {
            _dbContext.Products.Add(product);
            this.Save();
        }

        public void UpdateProduct(Product product)
        {
            _dbContext.Entry(product).State = EntityState.Modified;
            this.Save();
        }
        public void DeleteProduct(int productId)
        {
            var product = _dbContext.Products.Find(productId);
            _dbContext.Products.Remove(product);
            this.Save();
        }

        public void Save() =>
            _dbContext.SaveChanges();
    }
}
