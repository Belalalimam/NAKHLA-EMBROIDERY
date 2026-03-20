using ECommerce.Repositories.IRepositories;
using System.Threading.Tasks;

namespace ECommerce.Repositories
{
    public class ProductColorRepository : Repository<Color>, IProductColorRepository
    {
        private ApplicationDbContext _context;// = new();

        public ProductColorRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void RemoveRange(IEnumerable<Color> productColors)
        {
            _context.RemoveRange(productColors);
        }
    }
}