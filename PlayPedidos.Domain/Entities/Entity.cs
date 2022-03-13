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
	}
}
