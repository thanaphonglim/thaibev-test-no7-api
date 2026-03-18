using thaibevTest.Application.Features.Products.DeleteProduct;
using thaibevTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace thaibevTest.Application.Interfaces
{
    public interface IProductRepository
    {
        Task AddAsync(Product product);
        Task DeleteAsync(int id);
        Task<List<Product>> GetAllAsync();
        Task<List<Product>> SearchByKeywordAsync(string keyword);

        Task<bool> ExistsByCodeAsync(string code);
    }
}
