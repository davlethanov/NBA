using Microsoft.EntityFrameworkCore;
using System;
using System.Configuration;
using System.IO;

namespace NBA.Infrastructure.Data
{
    public class NBADataContext : DbContext
    {
		internal const string Schema = "NBA";

        public NBADataContext()
            : base(GetDbContextOptions())
        {
        }

        public NBADataContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TeamEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new GameEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PlayerEntityTypeConfiguration());

            modelBuilder.UsePropertyAccessMode(PropertyAccessMode.Field);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                entityType.SetSchema(Schema);
            }

            base.OnModelCreating(modelBuilder);
        }

        private static DbContextOptions GetDbContextOptions()
        {
            var configFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\NBA.Web\client.config");

            var fileMap = new ExeConfigurationFileMap { ExeConfigFilename = configFilePath };
            var config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            return new DbContextOptionsBuilder()
                .UseSqlServer(config.ConnectionStrings.ConnectionStrings["db"].ConnectionString)
                .Options;
        }
    }
}
