using DezContas.Data.Repositories;
using PlayPedidos.Domain.Entities;
using PlayPedidos.Domain.Interfaces.Repositories;

namespace PlayPedidos.Infra.Data.Repositories
{
	public class ProductRepository : RepositoryBase<Product>, IProductRepository
	{
		private readonly AppDbContext _context;
		public ProductRepository(AppDbContext context) : base(context)
		{
			_context = context;
		}
	}
}
