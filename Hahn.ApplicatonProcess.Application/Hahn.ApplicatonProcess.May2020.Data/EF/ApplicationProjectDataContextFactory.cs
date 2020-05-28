using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.May2020.Data.EF
{
    public class ApplicationProjectDataContextFactory : IDesignTimeDbContextFactory<ApplicationProjectDataContext>
    {
        public ApplicationProjectDataContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration =
                new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Migrations.json")
                .Build();

            var builder = new DbContextOptionsBuilder<ApplicationProjectDataContext>();

            var connectionString = configuration.GetConnectionString("DataBaseConn");

            builder.UseMySql(connectionString);

            return new ApplicationProjectDataContext(builder.Options);
        }

    }
}
