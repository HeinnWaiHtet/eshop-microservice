
using Catalog.API.Products.GetProducts;
using Marten.Linq.QueryHandlers;

namespace Catalog.API.Products.GetProductByCategory;

public record GetProductByCategoryQuery(string Category): IQuery<GetProductByCategoryResult>;

public record GetProductByCategoryResult(IEnumerable<Product> Products);

public class GetProductByCategoryHandler
	:IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
{
    private IDocumentSession session;
    public GetProductByCategoryHandler(IDocumentSession session)
    {
        this.session = session;
    }

    public async Task<GetProductByCategoryResult> Handle(
        GetProductByCategoryQuery query,
        CancellationToken cancellationToken)
    {
        var result = await this.session.Query<Product>()
            .Where(p => p.Category.Contains(query.Category))
            .ToListAsync();

        return new GetProductByCategoryResult(result);
    }
}

