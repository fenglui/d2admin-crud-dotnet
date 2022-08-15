using AutoMapper;
using System.Collections.Generic;
using System.Data;
using System.Text.Json;
using DC = d2admin.API.DataContracts;
using S = d2admin.Services.Model;

namespace d2admin.IoC.Configuration.AutoMapper.Profiles
{
    public class APIMappingProfile : Profile
    {
        public APIMappingProfile()
        {
            CreateMap<DC.User, S.User>().ReverseMap();
            //CreateMap<PagedList<DC.User>, PagedList<S.User>>().ReverseMap();

            CreateMap<DC.Role, S.Role>().ReverseMap();

            CreateMap<DC.ParentUserPermission, S.pm_resource>().ReverseMap();
            CreateMap<DC.Department, S.Department>().ReverseMap();

            CreateMap<DC.CdnFile, S.CdnFile>()
                //.ForMember(dest => dest.Pictures, opt => opt.MapFrom(src => src.PicturesJson))
                .ReverseMap();
        }
    }
}
