using FluentValidation.Results;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayPedidos.Domain.Entities
{
	public abstract class Entity
	{
		public int ID { get; set; }

		[NotMapped]
		public ValidationResult ValidationResult { get; set; }

		public Entity()
		{
		}

		public virtual bool IsValid()
		{
			throw new NotImplementedException();
		}
	}
}
