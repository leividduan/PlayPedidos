namespace PlayPedidos.Infra.Extensions
{
	public static class ListExtensions
	{
		public static bool IsNullOrEmpty(this IEnumerable<T> list)
		{
			return list != null && list.IsNullOrEmpty();
		}
	}
}
