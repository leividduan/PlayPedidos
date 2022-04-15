using FluentValidation.Results;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayPedidos.Domain.Entities
{
	public abstract class Entity
	{
		public int ID { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }

		[NotMapped]
		public ValidationResult ValidationResult { get; set; }

		public Entity()
		{
			var now = DateTime.Now;
			CreatedAt = now;
			UpdatedAt = now;

			ValidationResult = new ValidationResult();
		}

		public virtual bool IsValid()
		{
			throw new NotImplementedException();
		}

		public Error GetErrors()
		{
			var errorsDetail = ValidationResult.Errors.GroupBy(x => new { x.PropertyName }).Select(x => new ErrorDetails { Field = x.Key.PropertyName, Messages = x.Select(s => s.ErrorMessage).ToList() }).ToList();

			if (!errorsDetail.Any())
				return null;

			var errors = new Error { Errors = errorsDetail };

			return errors;
		}
	}
}
