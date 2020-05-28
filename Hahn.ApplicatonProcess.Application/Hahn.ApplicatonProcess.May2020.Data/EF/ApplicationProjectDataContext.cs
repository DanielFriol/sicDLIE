using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.May2020.Data.EF
{
    public class ApplicationProjectDataContext : DbContext
    {
        private readonly IConfiguration _config;
        public ApplicationProjectDataContext(IConfiguration config) => _config = config;
        public ApplicationProjectDataContext(DbContextOptions<ApplicationProjectDataContext> options) : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_config != null) optionsBuilder.UseMySql(_config.GetConnectionString("DataBaseConn"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Maps.PersonMap());
            modelBuilder.Seed();
        }


    }
}
