using Literature.Application.Contracts.Services;
using Literature.Application.Mappings;
using Literature.Application.Services;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Literature.Application
{
    public static class Container
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            MappingProfile.Configure();
            services.AddSingleton(TypeAdapterConfig.GlobalSettings);
            services.AddScoped<IMapper, ServiceMapper>();

            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IAuthorService, AuthorService>();

            return services;
        }
    }
}
