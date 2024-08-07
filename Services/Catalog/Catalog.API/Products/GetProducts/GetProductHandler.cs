﻿

namespace Catalog.API.Products.GetProducts;

public record GetProductsQuery(int? PageNumber = 1, int? PageSize = 10) : IQuery<GetProductsResult>;

public record GetProductsResult(IEnumerable<Product> Products);

public class GetProductHandler
    : IQueryHandler<GetProductsQuery, GetProductsResult>
{
    private IDocumentSession _session;
    public GetProductHandler(IDocumentSession session)
    {
        this._session = session;
    }

    public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
    {
        var products = await this._session.Query<Product>()
            .ToPagedListAsync(
            query.PageNumber ?? 1,
            query.PageSize ?? 10,
            cancellationToken);

        return new GetProductsResult(products);
    }
}

