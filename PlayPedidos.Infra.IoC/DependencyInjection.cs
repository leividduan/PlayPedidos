using DezContas.Data.Repositories;
using DezContas.Domain.Interfaces.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlayPedidos.Domain.Interfaces.Repositories;
using PlayPedidos.Infra.Data;
using PlayPedidos.Infra.Data.Repositories;
using System.Reflection;

namespace PlayPedidos.Infra.IoC
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<AppDbContext>(options =>
																					options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

			services.AddRepositories();

			services.AddFluentValidations();

			return services;
		}

		public static IServiceCollection AddRepositories(this IServiceCollection services)
		{
			services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
			services.AddScoped<IProductRepository, ProductRepository>();

			return services;
		}

		public static IServiceCollection AddFluentValidations(this IServiceCollection services)
		{
			return services.AddValidatorsFromAssembly(Assembly.Load("PlayPedidos.Domain"), ServiceLifetime.Transient);
		}
	}
}
