using ProductService.Model;

namespace ProductService.Services
{
    public class ProductRepository : IProductRepository
    {
        private static readonly IEnumerable<Product> products = new List<Product>()
        {
            new Product(1, "Budowa systemu ABC")
        };

        public ProductRepository()
        {

        }

        public IEnumerable<Product> GetAll()
        {
            return products;
        }

        
    }
}
