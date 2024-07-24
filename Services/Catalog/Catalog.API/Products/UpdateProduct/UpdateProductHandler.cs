
namespace Catalog.API.Products.UpdateProduct;

public record UpdaetProductCommand(
	Guid Id,
    string Name,
    List<string> Category,
    string Description,
    string ImageFile,
    decimal Price): ICommand<UpdateProductResult>;

public record UpdateProductResult(bool IsSuccess);

public class UpdateProductHandler
    :ICommandHandler<UpdaetProductCommand, UpdateProductResult>
{
    private IDocumentSession session;
    ILogger<UpdateProductHandler> logger;
    public UpdateProductHandler(IDocumentSession session, ILogger<UpdateProductHandler> logger)
    {
        this.session = session;
        this.logger = logger;
    }

    public async Task<UpdateProductResult> Handle(
        UpdaetProductCommand command,
        CancellationToken cancellationToken)
    {
        logger.LogInformation($"Update Product Handler called with {command}");

        var product = await session.LoadAsync<Product>(command.Id, cancellationToken);

        if (product is null) throw new ProductNotFoundException();

        product.Name = command.Name;
        product.Category = command.Category;
        product.Description = command.Description;
        product.ImageFile = command.ImageFile;
        product.Price = command.Price;

        var another = command.Adapt<Product>();

        session.Update(product);
        await session.SaveChangesAsync(cancellationToken);

        return new UpdateProductResult(true);
    }
}

