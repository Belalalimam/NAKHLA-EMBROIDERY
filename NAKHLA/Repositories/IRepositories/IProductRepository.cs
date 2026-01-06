using Microsoft.AspNetCore.Mvc;

namespace NAKHLA.Repositories.IRepositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task AddRangeAsync(IEnumerable<Product> products, CancellationToken cancellationToken = default);
    }
}
