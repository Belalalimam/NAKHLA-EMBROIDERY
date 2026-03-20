using Microsoft.EntityFrameworkCore;

namespace ECommerce.Repositories.IRepositories
{
    public interface IProductColorRepository : IRepository<Color>
    {
        void RemoveRange(IEnumerable<Color> productColors);
    }
}