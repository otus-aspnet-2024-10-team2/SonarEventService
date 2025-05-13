using Infrastructure.EntityFramework;
using Infrastructure.Repositories.Implementations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Abstractions;
using Services.Implementations;
using Services.Repositories.Abstractions;
using WebApi.Settings;

namespace WebApi
{
    /// <summary>
    /// Регистратор сервиса.
    /// </summary>
    public static class Registrar
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            var applicationSettings = configuration.Get<ApplicationSettings>();
            services.AddSingleton(applicationSettings)
                    .AddSingleton((IConfigurationRoot)configuration)
                    .InstallServices()
                    .ConfigureContext(applicationSettings.ConnectionString)
                    .InstallRepositories();
            return services;
        }
        
        private static IServiceCollection InstallServices(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddTransient<ISearchEventService, SonarProcessService>()
                .AddTransient<ISearchTaskService, SearchTaskService>()
                .AddTransient<IGroupMemberService, GroupMemberService>()
                .AddTransient<ISearchGroupService, SearchGroupService>();
            return serviceCollection;
        }
        
        private static IServiceCollection InstallRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddTransient<ISonarProcessRepository, SearchEventRepository>()
                .AddTransient<ISearchTaskRepository, SearchTaskRepository>()
                .AddTransient<ISearchGroupRepository, SearchGroupRepository>()
                .AddTransient<IGroupMemberRepository, GroupMemberRepository>()
                .AddTransient<IUnitOfWork, UnitOfWork>();
            return serviceCollection;
        }
    }
}