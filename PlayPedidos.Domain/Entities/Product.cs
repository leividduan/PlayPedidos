using PlayPedidos.Domain.Entities.Validators;

namespace PlayPedidos.Domain.Entities
{
	public class Product : Entity
	{
		public string Name { get; private set; }
		public string Description { get; private set; }
		public string UrlPhoto { get; private set; }
		public bool IsActive { get; private set; }

		public Product(string name, string description, string urlPhoto, bool isActive)
		{
			Name = name;
			Description = description;
			UrlPhoto = urlPhoto;
			IsActive = isActive;
		}

		public void Activate()
		{
			IsActive = true;
		}

		public void Deactivate()
		{
			IsActive = false;
		}

		public void Update(string name, string description, string urlPhoto)
		{
			Name = name;
			Description = description;
			UrlPhoto = urlPhoto;

			UpdatedAt = DateTime.Now;
		}

		public override bool IsValid()
		{
			ValidationResult = new ProductValidator().Validate(this);
			return ValidationResult.IsValid;
		}
	}
}
