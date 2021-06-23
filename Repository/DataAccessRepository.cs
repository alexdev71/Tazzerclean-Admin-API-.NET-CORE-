using Autofac;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Database
{
    public class DataAccessRepository : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            var assembly = typeof(DataAccessRepository).Assembly;
            var config = new ConfigurationBuilder()
                .AddJsonFile("connectionStrings.json", optional: false)
                .Build();
            builder.RegisterType<SqlConnection>()
                .WithParameter("connectionString", config.GetConnectionString("Data"))
                .As<IDbConnection>();
            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();
        }
    }
}
