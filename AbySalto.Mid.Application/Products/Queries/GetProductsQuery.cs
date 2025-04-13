using MediatR;
using AbySalto.Mid.Application.Contracts.Product;

public class GetProductsQuery : IRequest<List<ProductDto>>
{
    public int Page { get; set; }
    public int PageSize { get; set; }
}
