﻿using Infrastructure.EntityFramework;
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
                .AddTransient<ISearchEventService, SearchEventService>()
                .AddTransient<ISearchTaskService, SearchTaskService>()
                .AddTransient<IGroupMemberService, GroupMemberService>()
                .AddTransient<ISearchGroupService, SearchGroupService>()
                .AddTransient<ISearchAnnouncementService, SearchAnnouncementService>()
                .AddTransient<ISearchRequestService, SearchRequestService>()
                .AddTransient<IAnimalService, AnimalService>()
                .AddTransient<IUserService, UserService>();
            return serviceCollection;
        }
        
        private static IServiceCollection InstallRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddTransient<ISearchEventRepository, SearchEventRepository>()
                .AddTransient<ISearchTaskRepository, SearchTaskRepository>()
                .AddTransient<ISearchGroupRepository, SearchGroupRepository>()
                .AddTransient<IGroupMemberRepository, GroupMemberRepository>()
                .AddTransient<ISearchAnnouncementRepository, SearchAnnouncementRepository>()
                .AddTransient<ISearchRequestRepository, SearchRequestRepository>()
                .AddTransient<IUserRepository, UserRepository>()
                .AddTransient<IAnimalRepository, AnimalRepository>()
                .AddTransient<IUnitOfWork, UnitOfWork>();
            return serviceCollection;
        }
    }
}