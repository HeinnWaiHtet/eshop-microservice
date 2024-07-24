﻿
namespace Catalog.API.Products.GetProductById;

// public record GetProductByIdRequest();

public record GetProductByIdResponse(Product Product);

public class GetProductByIdEndPoint : ICarterModule
{
	public GetProductByIdEndPoint()
	{
	}

    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/{id}", async (Guid id, ISender sender) =>
        {
            var result = await sender.Send(new GetProductByIdQuery(id));

            var response = result.Adapt<GetProductByIdResponse>();
            return Results.Ok(response);
        })
        .WithName("Get Product By Id")
        .Produces<GetProductByIdResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithDescription("GET ProductBy Id")
        .WithSummary("Get Product by Id");
    }
}

