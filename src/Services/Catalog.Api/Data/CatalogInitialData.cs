using Bogus;
using Marten.Schema;

namespace Catalog.Api.Data;

public class CatalogInitialData : IInitialData
{
    public async Task Populate(IDocumentStore store, CancellationToken cancellation)
    {
        await using IDocumentSession session = store.LightweightSession();

        if (await session.Query<Product>().AnyAsync(cancellation)) return;

        session.Store(GetPreconfiguredProducts());
        await session.SaveChangesAsync(cancellation);
    }

    private static IEnumerable<Product> GetPreconfiguredProducts()
    {
        Faker<Product>? productFaker = new Faker<Product>()
            .RuleFor(p => p.Id, f => f.Random.Guid())
            .RuleFor(p => p.Name, f => f.Commerce.ProductName())
            .RuleFor(p => p.Category, f => [f.Commerce.Categories(1)[0]])
            .RuleFor(p => p.Description, f => f.Lorem.Sentence())
            .RuleFor(p => p.ImageFile, f => f.Image.PicsumUrl())
            .RuleFor(p => p.Price, f => f.Random.Decimal(1, 1000));
        return productFaker.Generate(10);
    }
}