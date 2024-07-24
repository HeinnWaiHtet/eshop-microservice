
using Marten.Linq.QueryHandlers;

namespace Catalog.API.Products.GetProducts;

public record GetProductsQuery(): IQuery<GetProductsResult>;

public record GetProductsResult(IEnumerable<Product> Products);

public class GetProductHandler
    : IQueryHandler<GetProductsQuery, GetProductsResult>
{
    private IDocumentSession _session;
    ILogger<GetProductHandler> logger;
    public GetProductHandler(IDocumentSession session, ILogger<GetProductHandler> logger)
    {
        this._session = session;
        this.logger = logger;
    }

    public async Task<GetProductsResult> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("GetProductsQueryHandler Called");

        var products = await this._session.Query<Product>().ToListAsync(cancellationToken);

        return new GetProductsResult(products);
    }
}

