
using Marten.Linq.QueryHandlers;

namespace Catalog.API.Products.GetProducts;

public record GetProductsQuery(): IQuery<GetProductsResult>;

public record GetProductsResult(IEnumerable<Product> Products);

public class GetProductHandler
    : IQueryHandler<GetProductsQuery, GetProductsResult>
{
    private IDocumentSession _session;
    public GetProductHandler(IDocumentSession session)
    {
        this._session = session;
    }

    public async Task<GetProductsResult> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await this._session.Query<Product>().ToListAsync(cancellationToken);

        return new GetProductsResult(products);
    }
}

