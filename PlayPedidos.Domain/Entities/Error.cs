namespace PlayPedidos.Domain.Entities
{
	public class Error
	{
		public List<ErrorDetails> Errors { get; set; }
	}

	public class ErrorDetails
	{
		public string Field { get; set; }
		public List<string> Messages { get; set; }
	}
}
