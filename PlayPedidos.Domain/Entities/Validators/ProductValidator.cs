using FluentValidation;

namespace PlayPedidos.Domain.Entities.Validators
{
	public class ProductValidator : AbstractValidator<Product>
	{
		public ProductValidator()
		{
			RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Name is required")
				.MinimumLength(3).WithMessage("Minimum length must be 3 characters")
				.MaximumLength(150).WithMessage("Maximum length must be 150 characters");

			RuleFor(x => x.Description).MaximumLength(2000).WithMessage("Maximum length must be 2000 characters");

			RuleFor(x => x.UrlPhoto).MaximumLength(150).WithMessage("Maximum length must be 150 characters");
		}
	}
}
