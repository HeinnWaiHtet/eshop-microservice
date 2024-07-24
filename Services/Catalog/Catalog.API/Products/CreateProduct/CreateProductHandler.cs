
namespace Catalog.API.Products.CreateProduct;

public record CreateProductCommand(
    string Name,
    List<string> Category,
    string Description,
    string ImageFile,
    decimal Price): ICommand<CreateProductResult>;

public record CreateProductResult(Guid Id);

public class CreateProductCommandValidator: AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Category).NotEmpty().WithMessage("Category is required");
        RuleFor(x => x.ImageFile).NotEmpty().WithMessage("ImageFile is required");
        RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price Must Be Greate Than 0");
    }
}

public class CreateProductCommandHandler
    : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    private IDocumentSession _session;
    public CreateProductCommandHandler(
        IDocumentSession session)
    {
        this._session = session;
    }

    public async Task<CreateProductResult> Handle(
        CreateProductCommand command,
        CancellationToken cancellationToken)
    {
        // Create Product Entity From Command Object
        var product = new Product
        {
            Name = command.Name,
            Category = command.Category,
            Description = command.Description,
            ImageFile = command.ImageFile,
            Price = command.Price
        };

        // Save To Database
        this._session.Store(product);
        await this._session.SaveChangesAsync(cancellationToken);

        // return CreateProductResult result
        return new CreateProductResult(Guid.NewGuid());
    }
}

