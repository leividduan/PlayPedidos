namespace PlayPedidos.API.ViewModel
{
	public record ProductViewModel(
		int ID,
		string Name,
		string Description,
		string UrlPhoto,
		bool IsActive,
		DateTime CreatedAt,
		DateTime UpdatedAt
	);

	public record ProductPostViewModel(
		string Name,
		string Description,
		string UrlPhoto,
		bool IsActive
	);

	public record ProductPutViewModel(
		int ID,
		string Name,
		string Description,
		string UrlPhoto,
		bool IsActive
	);
}
