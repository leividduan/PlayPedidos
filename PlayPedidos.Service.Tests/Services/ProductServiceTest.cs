using Moq;
using PlayPedidos.Application.Services;
using PlayPedidos.Domain.Entities;
using PlayPedidos.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using Xunit;

namespace PlayPedidos.Application.Tests.Services
{
	public class ProductServiceTest
	{
		[Fact]
		[Trait("Service", "ProductService")]
		public async void ProductService_Get_ReturnsAllProducts()
		{
			// Arrange
			var mock = new Mock<IProductRepository>();
			mock.Setup(c => c.Get(null, null)).ReturnsAsync(GetTestProducts);
			var service = new ProductService(mock.Object);

			// Act
			var result = await service.Get();

			// Assert
			Assert.NotNull(result);
			Assert.NotEmpty(result);
		}

		private List<Product> GetTestProducts()
		{
			return new List<Product>
						{
								new Product("Teste1", "Descricao1", "photo1.jpg", true),
								new Product("Teste2", "Descricao2", "photo2.jpg", true),
								new Product("Teste3", "Descricao3", "photo3.jpg", true)
						};
		}
	}
}
