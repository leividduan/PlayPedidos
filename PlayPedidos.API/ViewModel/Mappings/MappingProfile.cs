using AutoMapper;
using PlayPedidos.API.ViewModel;
using PlayPedidos.Domain.Entities;

namespace PlayPedidos.API.DTOs.Mappings
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Error, ErrorViewModel>().ReverseMap();
			CreateMap<ErrorDetails, ErrorDetailsViewModel>().ReverseMap();

			CreateMap<Product, ProductViewModel>().ReverseMap();
			CreateMap<Product, ProductPostViewModel>().ReverseMap();
			CreateMap<Product, ProductPutViewModel>().ReverseMap();
		}
	}
}
