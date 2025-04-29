using Literature.Domain.Repositories;
using Literature.Infrastructure.Api;
using Literature.Infrastructure.Contracts.Api;
using Literature.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Literature.Infrastructure
{
    public static class Container
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<IApiClient, ApiClient>(client =>
            {
                var baseAddress = configuration.GetSection("Api:BaseAddress").Value;

                if (!string.IsNullOrEmpty(baseAddress))
                {
                    client.BaseAddress = new Uri(baseAddress);
                }

                client.DefaultRequestHeaders.Add("Accept", "text/plain");
            });

            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            return services;
        }
    }
}
