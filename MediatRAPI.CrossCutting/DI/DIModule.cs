using AutoMapper;
using DDDAPI.Application.App;
using DDDAPI.Application.App.Interface;
using DDDAPI.Domain.Interfaces.TeamRepository;
using DDDAPI.Persistence.EFCore.Context;
using DDDAPI.Persistence.EFCore.Repository.TeamRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace DDDAPI.CrossCutting.DI
{
    public class DIModule
    {
        public static void ConfigureDbConnection(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("MediatRDb");

            serviceCollection.AddDbContext<MediatRContext>(options =>
                                                      options.UseSqlServer(connectionString));
        }

        public static void ConfigureClassesDI(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ITeamApplication, TeamApplication>();
            #region [ Repository ]

            serviceCollection.AddScoped<ITeamRepository, TeamRepository>();

            #endregion [ Repository ]

            Type[] typelist = GetTypesInNamespace(Assembly.GetExecutingAssembly(), "MediatRAPI.CrossCutting.Mapper");

            Type[] GetTypesInNamespace(Assembly assembly, string nameSpace)
            {
                return
                  assembly.GetTypes()
                          .Where(t => string.Equals(t.Namespace, nameSpace, StringComparison.Ordinal))
                          .ToArray();
            }

            serviceCollection.AddAutoMapper(typelist);
        }
    }
}
