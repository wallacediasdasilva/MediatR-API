using AutoMapper;
using MediatRAPI.Domain.Interfaces.UserRepository;
using MediatRAPI.Persistence.EFCore.Context;
using MediatRAPI.Persistence.EFCore.Repository.UserRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace MediatRAPI.CrossCutting.DI
{
    public class DIModule
    {
        public static void ConfigureDbConnection(IServiceCollection serviceCollection)
        {
            var configuration = ConfigureJson();

            string connectionString = configuration.GetConnectionString("MediatRDb");

            serviceCollection.AddDbContext<MediatRContext>(options =>
                                                      options.UseSqlServer(connectionString));
        }

        private static IConfiguration ConfigureJson()
        {
            var sharedFolder = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\Shared"));

            return new ConfigurationBuilder().AddJsonFile(Path.Combine(sharedFolder, "Config.json")).Build();
        }

        public static void ConfigureClassesDI(IServiceCollection serviceCollection)
        {
            #region [ Repository ]

            serviceCollection.AddScoped<IUserRepository, UserRepository>();

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
