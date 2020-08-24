using Autofac;
using FastRecipe.Infrastructure.Repositories;
using FastRecipe.Domain.AggregatesModel.UserAggregate;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using FastRecipe.Domain.SeedWork;
using FastRecipe.Infrastructure.Mappers.Implementations;
using FastRecipe.Infrastructure.Mappers.Interfaces;
using FastRecipe.Domain.AggregatesModel.RecipeAggregate;

namespace FastRecipe.Infrastructure.IoC
{
    public static class ConfigurationIoC
    {
        private static IMongoDatabase database;

        private static IEnumerable<IConfigurationSection> _configurationsSections { get; set; }
        private static IMongoDatabase Database 
        {
            get {
                if (database is null)
                    database = GetDatabase();

                return database;
            }
        }

        public static void Load(ContainerBuilder builder, IEnumerable<IConfigurationSection> sections)
        {
            _configurationsSections = sections;

            #region IoC

            builder.RegisterType<UsersRepository>().As<IGenericRepository<User>>().WithParameter("database", Database).SingleInstance();
            builder.RegisterType<RecipeRepository>().As<IGenericRepository<Recipe>>().WithParameter("database", Database).SingleInstance();
            builder.RegisterType<MapperUser>().As<IMapper<UserDTO, User>>();
            builder.RegisterType<MapperRecipe>().As<IMapper<RecipeDTO, Recipe>>();

            #endregion
        }

        private static IMongoDatabase GetDatabase()
        {
            var client = new MongoClient(GetValueFromConfigurationSection("ConnectionString"));
            var database = client.GetDatabase(GetValueFromConfigurationSection("DatabaseName"));
            return database;
        }

        private static string GetValueFromConfigurationSection(string key) => _configurationsSections.Where(s => s.Key == key).FirstOrDefault().Value;
    }
}
