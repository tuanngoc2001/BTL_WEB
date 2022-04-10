using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_Data.EF
{
    public class ImDbContextFactory : IDesignTimeDbContextFactory<ImDbContext>

    {
        public ImDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();
            var optionsBuilder = new DbContextOptionsBuilder<ImDbContext>();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("MyDb"));
            return new ImDbContext(optionsBuilder.Options);
        }
    }
}
