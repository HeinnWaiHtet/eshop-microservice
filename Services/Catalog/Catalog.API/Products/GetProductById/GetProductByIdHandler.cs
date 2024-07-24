
using Catalog.API.Products.GetProducts;
using Marten.Linq.QueryHandlers;

namespace Catalog.API.Products.GetProductById;

public record GetProductByIdQuery(Guid Id): IQuery<GetProductByIdResult>;

public record GetProductByIdResult(Product Product);

public class GetProductByIdHandler
	: IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
{
    private IDocumentSession _session;
    public GetProductByIdHandler(IDocumentSession session)
    {
        this._session = session;
    }

    public async Task<GetProductByIdResult> Handle(
        GetProductByIdQuery query,
        CancellationToken cancellationToken)
    {
        var result = await this._session.LoadAsync<Product>(query.Id, cancellationToken);

        if(result is null)
        {
            throw new ProductNotFoundException(query.Id);
        }

        return new GetProductByIdResult(result);
    }
}

