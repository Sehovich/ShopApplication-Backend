using AbySalto.Mid.Application.Contracts.Product;
using MediatR;

public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<ProductDto>>
{
    private readonly IProductProxyService _productService;

    public GetProductsQueryHandler(IProductProxyService productService)
    {
        _productService = productService;
    }

    public async Task<List<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var skip = (request.Page - 1) * request.PageSize;
        return await _productService.GetProductsAsync(skip, request.PageSize);
    }
}
