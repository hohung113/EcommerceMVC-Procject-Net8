using AutoMapper;
using EcommerceMVC.Data;
using EcommerceMVC.ViewModels;

namespace EcommerceMVC.Helper
{
	public class AutoMapperProfile : Profile
	{
        public AutoMapperProfile()
        {
			CreateMap<RegisterVM, KhachHang>().ReverseMap();
		}
    }
	
}
