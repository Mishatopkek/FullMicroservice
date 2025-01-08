namespace Catalog.Api.Exceptions;

public class ProductNotFoundException(Guid id) : NotFoundException("Product", id);