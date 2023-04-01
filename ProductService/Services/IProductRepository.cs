using ProductService.Model;

namespace ProductService.Services
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
    }
}
