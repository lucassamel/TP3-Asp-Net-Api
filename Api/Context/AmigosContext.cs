using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Context
{
    public class AmigosContext : DbContext
    {
        public AmigosContext(DbContextOptions<AmigosContext> options) : base(options)
        {

        }

        public virtual DbSet<Amigo> Amigos { get; set; }

        public class DesingTimeDbContextFactory : IDesignTimeDbContextFactory<AmigosContext>
        {
            public AmigosContext CreateDbContext(string[] args)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/appsettings.json").Build();

                var builder = new DbContextOptionsBuilder<AmigosContext>();
                var connectionString = configuration.GetConnectionString("DatabaseConnection");
                builder.UseSqlServer(connectionString);

                return new AmigosContext(builder.Options);
            }
        }
    }
}
