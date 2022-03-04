namespace PlayPedidos.Domain.ValueObjects
{
	public enum Currency
	{
		BRL = 1,
		USD = 2,
		EUR = 3,
	}

	public class Price
	{
		public decimal Value { get; set; }
		public Currency Currency { get; set; }

		public Price()
		{
		}

		public Price(decimal value)
		{
			Value = value;
		}

		public Price(decimal value, Currency currency)
		{
			Value = value;
			Currency = currency;
		}
	}
}
