using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClientLandingPage.Models;
using ClientLandingPage.ViewModels;

namespace ClientLandingPage.ConfigServices
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Client, ClientSubmitViewModel>().ReverseMap()
                .ForMember(a => a.UploadFile, b => b.ResolveUsing(a => a.UploadFile.FileName));
        }

        private void AfterMap(Func<object, object, object> p)
        {
            throw new NotImplementedException();
        }
    }

    public static class MapperConfigService
    {
        public static IServiceCollection RegisterMapper(this IServiceCollection services)
        {
            services.AddAutoMapper();

            return services;
        }
    }
}
