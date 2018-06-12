using AutoMapper;
using ProviderService.data.models;
using ProviderService.data.ViewModels;
namespace ProviderService.data.AutoMapperProfiles
{
    public class ProviderProfile : Profile
    {
        //Example Profile for mapping with Automapper
        public ProviderProfile(){
            CreateMap<TbuProvider, ProviderVM>()
                .ForMember(dest => dest.Name,
                            opts => opts.MapFrom(
                                src => src.ProviderType == "Facility" ? src.Facility.FacilityName : src.Physician.FirstName + " " + src.Physician.MiddleName + " "  + src.Physician.LastName 
                            ));
                
            
        }

    }
}