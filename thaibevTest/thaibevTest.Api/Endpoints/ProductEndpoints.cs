using thaibevTest.Application.Features.Products.CreateProduct;
using thaibevTest.Application.Features.Products.DeleteProduct;
using thaibevTest.Application.Features.Products.GetProducts;
using thaibevTest.Application.Features.Products.SearchProducts;

namespace thaibevTest.Api.Endpoints
{
    public static class ProductEndpoints
    {
        public static RouteGroupBuilder MapProductEndpoints(this RouteGroupBuilder group)
        {
            group.MapPost("/", async (
                CreateProductCommand command,
                CreateProductHandler handler) =>
            {
                await handler.Handle(command);
                return Results.Ok();
            });

            group.MapGet("/", async (
                GetProductsHandler handler) =>
            {
                return Results.Ok(await handler.Handle());
            });

            group.MapGet("search", async (
                [AsParameters] SearchProductQuery query,
                SearchProductsHandler handler) =>
            {
                return Results.Ok(await handler.Handle(query));
            });

            group.MapDelete("/{id}", async (
                int id,
                DeleteProductHandler handler) =>
            {
                await handler.Handle(id);
                return Results.NoContent();
            });

            return group;
        }
    }
}
