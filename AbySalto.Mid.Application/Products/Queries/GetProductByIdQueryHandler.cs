using AbySalto.Mid.Application.Contracts.Product;
using MediatR;

namespace AbySalto.Mid.Application.Products.Queries;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto?>
{
    private readonly IProductProxyService _proxy;

    public GetProductByIdQueryHandler(IProductProxyService proxy)
    {
        _proxy = proxy;
    }

    public async Task<ProductDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        return await _proxy.GetProductByIdAsync(request.ProductId, cancellationToken);
    }
}
