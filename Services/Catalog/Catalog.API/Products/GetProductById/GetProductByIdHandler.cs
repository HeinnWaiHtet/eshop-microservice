
using Catalog.API.Products.GetProducts;
using Marten.Linq.QueryHandlers;

namespace Catalog.API.Products.GetProductById;

public record GetProductByIdQuery(Guid Id): IQuery<GetProductByIdResult>;

public record GetProductByIdResult(Product Product);

public class GetProductByIdHandler
	: IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
{
    private IDocumentSession _session;
    ILogger<GetProductHandler> logger;
    public GetProductByIdHandler(IDocumentSession session, ILogger<GetProductHandler> logger)
    {
        this._session = session;
        this.logger = logger;
    }

    public async Task<GetProductByIdResult> Handle(
        GetProductByIdQuery query,
        CancellationToken cancellationToken)
    {
        logger.LogInformation($"Get Product By Id called {query.Id}");

        var result = await this._session.LoadAsync<Product>(query.Id, cancellationToken);

        if(result is null)
        {
            throw new ProductNotFoundException();
        }

        return new GetProductByIdResult(result);
    }
}

