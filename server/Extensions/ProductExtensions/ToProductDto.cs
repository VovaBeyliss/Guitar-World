using GuitarWorld.Models;
using GuitarWorld.Dtos;

namespace GuitarWorld.Extensions;

public static class ProductExtensions {
    public static GetProductDto ToProductDto(this Product source) => new GetProductDto(source.Price, source.Quantity, source.Name, source.Type, source.Brand);
}