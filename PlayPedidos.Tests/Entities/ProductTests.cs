using PlayPedidos.Domain.Entities;
using Xunit;

namespace PlayPedidos.Tests.Entities
{
	public class ProductTests
	{
		[Fact]
		[Trait("Category", "Product")]
		public void Product_Create_Successfully()
		{
			var product = new Product("iPhone", "Modelo 11", "/Photos/iphone.jpg", true);

			Assert.True(product.IsValid());
		}

		[Fact]
		[Trait("Category", "Product")]
		public void Product_Create_Without_Name()
		{
			var product = new Product(null, "Produto teste", "/Photos/iphone.jpg", true);

			Assert.False(product.IsValid());
		}

		[Fact]
		[Trait("Category", "Product")]
		public void Product_Create_Invalid_Min_Length_Name()
		{
			var product = new Product("Oi", "Produto Oi", "/Photos/oi.jpg", true);

			Assert.False(product.IsValid());
		}

		[Fact]
		[Trait("Category", "Product")]
		public void Product_Create_Invalid_Max_Length_Name()
		{
			var product = new Product("iPhone maravilhoso você deveria comprar essa belezinha, não vai se arrepender dessa aquisição, confia! Melhor preço da internet, com certeza, entre em contanto.", "iPhone 11", "/Photos/iphone.jpg", true);

			Assert.False(product.IsValid());
		}

		[Fact]
		[Trait("Category", "Product")]
		public void Product_Create_Invalid_Max_Length_Description()
		{
			var description = @"Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.
													Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.
													Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.
													Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.";

			var product = new Product("iPhone", description, "/Photos/iphone.jpg", true);

			Assert.False(product.IsValid());
		}

		[Fact]
		[Trait("Category", "Product")]
		public void Product_Create_Invalid_Max_Length_UrlPhoto()
		{
			var product = new Product("iPhone", "iPhone 11", "/Users/Leonardo Da Vinci/Photos/Ideias/Vendas/Testes/Photos/Ideias/Vendas/Testes/Photos/Ideias/Vendas/Testes/Photos/Ideias/Vendas/Testes/iphonevenda.jpg", true);

			Assert.False(product.IsValid());
		}
	}
}
