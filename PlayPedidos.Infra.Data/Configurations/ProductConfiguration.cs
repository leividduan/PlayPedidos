using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlayPedidos.Domain.Entities;

namespace PlayPedidos.Infra.Data.Configurations
{
	public class ProductConfiguration : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			//Key
			builder.HasKey(i => i.ID);

			builder.Property(i => i.Name)
				.IsRequired()
				.HasMaxLength(150);

			builder.Property(i => i.Description)
				.HasMaxLength(4000);

			builder.Property(i => i.UrlPhoto)
				.HasMaxLength(150);
		}
	}
}
