using thaibevTest.Application.Common.Helpers;
using thaibevTest.Application.Interfaces;
using thaibevTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace thaibevTest.Application.Features.Products.GetProducts
{
    public class GetProductsHandler
    {
        private readonly IProductRepository _repository;
        public GetProductsHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ProductResponse>> Handle()
        {
            var products = await _repository.GetAllAsync();

            return products.Select(product => new ProductResponse
            {
                Id = product.Id,
                ProductCode = product.ProductCode,
                FormattedProductCode = ProductCodeFormatter.Format(product.ProductCode)
            }).ToList();
        }
    }
}
