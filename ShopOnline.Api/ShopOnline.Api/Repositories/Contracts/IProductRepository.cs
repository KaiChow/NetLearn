using ShopOnline.Api.Entities;

namespace ShopOnline.Api.Repositories.Contracts
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetItem(int id);
        Task<IEnumerable<ProductCategory>> GetCategories();
        Task<ProductCategory> GetCategory(int id);
    }
}
