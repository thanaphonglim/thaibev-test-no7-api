using System;
using System.Collections.Generic;
using System.Text;

namespace thaibevTest.Application.Features.Products.GetProducts
{
    public class ProductResponse
    {
        public int Id { get; set; }
        public string? ProductCode { get; set; }
        public string? FormattedProductCode { get; set; }
    }
}
