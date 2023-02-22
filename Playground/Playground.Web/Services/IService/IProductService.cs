using Playground.Web.Models;

namespace Playground.Web.Services.IService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> FindAllProducts(string token);
        Task<ProductModel> GetProductById(long id, string token);
        Task<ProductModel> CreateProduct(ProductModel model, string token);
        Task<ProductModel> UpdateProduct(ProductModel model, string token);
        Task<bool> DeleteProduct(long id, string token);
    }
}
