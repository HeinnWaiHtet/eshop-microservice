
using Catalog.API.Products.UpdateProduct;

namespace Catalog.API.Products.DeleteProduct;

public record DeleteProductCommand(Guid Id): ICommand<DeleteProductResult>;

public record DeleteProductResult(bool IsSuccess);

public class DeleteProductHandler
    : ICommandHandler<DeleteProductCommand, DeleteProductResult>
{
    private IDocumentSession session;
    ILogger<DeleteProductHandler> logger;
    public DeleteProductHandler(IDocumentSession session, ILogger<DeleteProductHandler> logger)
    {
        this.session = session;
        this.logger = logger;
    }

    public async Task<DeleteProductResult> Handle(
        DeleteProductCommand command,
        CancellationToken cancellationToken)
    {
        logger.LogInformation($"Delete Product By Id {command.Id}");

        session.Delete<Product>(command.Id);
        await session.SaveChangesAsync(cancellationToken);

        return new DeleteProductResult(true);
    }
}

