using System.Threading;
using System.Threading.Tasks;

namespace AbySalto.Mid.Application.Interfaces
{
    public interface IProductImportService
    {
        Task ImportProductsAsync(CancellationToken cancellationToken = default);
    }
}
