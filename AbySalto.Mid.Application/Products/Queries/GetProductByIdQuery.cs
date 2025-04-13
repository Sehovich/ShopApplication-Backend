using MediatR;
using AbySalto.Mid.Application.Contracts.Product;

namespace AbySalto.Mid.Application.Products.Queries;

public class GetProductByIdQuery : IRequest<ProductDto>
{
    public int ProductId { get; set; }
}
