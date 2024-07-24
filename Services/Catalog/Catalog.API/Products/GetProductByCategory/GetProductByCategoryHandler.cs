
using Catalog.API.Products.GetProducts;
using Marten.Linq.QueryHandlers;

namespace Catalog.API.Products.GetProductByCategory;

public record GetProductByCategoryQuery(string Category): IQuery<GetProductByCategoryResult>;

public record GetProductByCategoryResult(IEnumerable<Product> Products);

public class GetProductByCategoryHandler
	:IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
{
    private IDocumentSession session;
    ILogger<GetProductByCategoryHandler> logger;
    public GetProductByCategoryHandler(IDocumentSession session, ILogger<GetProductByCategoryHandler> logger)
    {
        this.session = session;
        this.logger = logger;
    }

    public async Task<GetProductByCategoryResult> Handle(
        GetProductByCategoryQuery query,
        CancellationToken cancellationToken)
    {
        this.logger.LogInformation($"Get Product By Category : {query.Category} ");

        var result = await this.session.Query<Product>()
            .Where(p => p.Category.Contains(query.Category))
            .ToListAsync();

        return new GetProductByCategoryResult(result);
    }
}

