using Microsoft.Extensions.DependencyInjection;


namespace SearchRepository.Application;

public static class ApplicationServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddDbContext<SearchRepositoryDBContext>();
        services.AddScoped<ISearchRepository, SearchServices>();
        services.AddScoped<ILoginServices, LoginServices>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
