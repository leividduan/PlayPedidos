using PlayPedidos.Domain.Entities.Validators;

namespace PlayPedidos.Domain.Entities
{
	public class Product : Entity
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public string UrlPhoto { get; set; }
		public bool IsActive { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }

		public Product()
		{
		}

		public Product(string name, string description, string urlPhoto, bool isActive)
		{
			Name = name;
			Description = description;
			UrlPhoto = urlPhoto;
			IsActive = isActive;
		}

		public override bool IsValid()
		{
			ValidationResult = new ProductValidator().Validate(this);
			return ValidationResult.IsValid;
		}
	}
}
