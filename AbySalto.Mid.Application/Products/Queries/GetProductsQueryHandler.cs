using AbySalto.Mid.Application.Contracts.Product;
using AbySalto.Mid.Application.Contracts.Common;
using AbySalto.Mid.Application.Interfaces;
using MediatR;

public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, PagedResult<ProductDto>>
{
    private readonly IProductService _productService;

    public GetProductsQueryHandler(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<PagedResult<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var items = await _productService.GetPagedAsync(request.Page, request.PageSize, cancellationToken);
        var total = await _productService.GetTotalCountAsync(cancellationToken);

        return new PagedResult<ProductDto>
        {
            Items = items,
            TotalCount = total
        };
    }
}
