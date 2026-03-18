using thaibevTest.Application.Common.Exceptions;
using thaibevTest.Application.Interfaces;
using thaibevTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace thaibevTest.Application.Features.Products.CreateProduct
{
    public class CreateProductHandler
    {
        private readonly IProductRepository _repository;
        public CreateProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateProductCommand command)
        {
            int retry = 5;
            while (retry-- > 0)
            {
                var product = Product.Create();

                try
                {
                    await _repository.AddAsync(product);
                    return;
                }
                catch (DuplicateProductCodeException){}
            }
        }
    }
}
