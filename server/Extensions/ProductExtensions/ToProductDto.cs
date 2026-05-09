namespace GuitarWorld.Extensions;

public static class ProductExtensions {
    public static ProductDto ToProductDto(this Product product) => new ProductDto(product.Price, product.Name, product.Type, product.Brand);
}