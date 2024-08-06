using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchRepository.Infrastructure;

public static class InfrastructureService
{
    public static IServiceCollection CreateContextService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<SearchRepositoryDBContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("Postgres"));
        });

        return services;
    }
}
