using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using Xunit;

namespace PlayPedidos.API.Tests
{
	public class UnitTest1
	{
		private readonly HttpClient _client;

		public UnitTest1()
		{
			var appFactory = new WebApplicationFactory<Program>();
			_client = appFactory.CreateClient();
		}

		[Fact]
		public void Test1()
		{
		}
	}
}