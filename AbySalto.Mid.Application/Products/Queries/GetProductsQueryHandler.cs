using AbySalto.Mid.Application.Contracts.Product;
using MediatR;

public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<ProductDto>>
{
    private readonly IProductService _productService;

    public GetProductsQueryHandler(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<List<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        return await _productService.GetPagedAsync(request.Page, request.PageSize, cancellationToken);
    }
}
