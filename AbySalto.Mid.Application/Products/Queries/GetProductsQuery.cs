using AbySalto.Mid.Application.Contracts.Product;
using AbySalto.Mid.Application.Contracts.Common;
using MediatR;

public class GetProductsQuery : IRequest<PagedResult<ProductDto>>
{
    public int Page { get; set; }
    public int PageSize { get; set; }
}
