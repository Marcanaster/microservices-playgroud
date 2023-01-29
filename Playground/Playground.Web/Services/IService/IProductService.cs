﻿using Playground.Web.Model;

namespace Playground.Web.Services.IService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> FindAllProducts();
        Task<ProductModel> GetProductById(long id);
        Task<ProductModel> CreateProduct(ProductModel model);
        Task<ProductModel> UpdateProduct(ProductModel model);
        Task<ProductModel> DeleteProduct(long id);
    }
}