using AmazonStoreMVC.Models;
namespace AmazonStoreMVC.Services
{
    public interface IProductService
    {
        List<Product> GetAll();
        Product GetById(int id);
        void Insert(Product pro);
        void Update(Product pro);
        void Delete(int id);
        
    }
}
