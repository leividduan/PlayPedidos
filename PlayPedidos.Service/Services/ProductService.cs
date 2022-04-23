using PlayPedidos.Domain.Entities;
using PlayPedidos.Domain.Interfaces.Repositories;
using PlayPedidos.Service.Interfaces;

namespace PlayPedidos.Service.Services
{
	public class ProductService : ServiceBase<Product>, IProductService
	{
		private readonly IProductRepository _repository;
		public ProductService(IProductRepository repository) : base(repository)
		{
			_repository = repository;
		}
	}
}
