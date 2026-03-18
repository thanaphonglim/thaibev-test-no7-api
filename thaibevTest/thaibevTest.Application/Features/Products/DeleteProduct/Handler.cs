using thaibevTest.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace thaibevTest.Application.Features.Products.DeleteProduct
{
    public class DeleteProductHandler
    {
        private readonly IProductRepository _repository;

        public DeleteProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
