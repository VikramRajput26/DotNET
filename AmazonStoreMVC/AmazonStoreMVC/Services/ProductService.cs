using AmazonStoreMVC.Models;
using AmazonStoreMVC.Repository;
using System.Collections.Generic;
using System.Linq;

namespace AmazonStoreMVC.Services
{
    public class ProductService : IProductService
    {
        private readonly EstoreControllerContext _context;

        public ProductService(EstoreControllerContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }

        public List<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product GetById(int id)
        {
            return _context.Products.Find(id);
        }

        public void Insert(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Update(Product product)
        {
            var existingProduct = _context.Products.Find(product.Id);
            if (existingProduct != null)
            {
                existingProduct.Title = product.Title;
                existingProduct.Description = product.Description;
                existingProduct.UnitPrice = product.UnitPrice;
                existingProduct.ImageUrl = product.ImageUrl;
                existingProduct.Quantity = product.Quantity;

                _context.SaveChanges();
            }
        }
    }
}
