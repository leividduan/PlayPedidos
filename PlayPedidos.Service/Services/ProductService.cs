using PlayPedidos.Application.Interfaces;
using PlayPedidos.Domain.Entities;
using PlayPedidos.Domain.Interfaces.Repositories;

namespace PlayPedidos.Application.Services
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
