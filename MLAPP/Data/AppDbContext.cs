using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MLAPP.Data.Entities;

namespace MLAPP.Data
{
    public class AppDbContext : DbContext
    {
        public IConfiguration _config { get; set; }
        public AppDbContext(/*IConfiguration config*/)
        {
            //_config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            // optionsBuilder.UseSqlServer(_config.GetConnectionString("DatabaseConnection"));
            optionsBuilder.UseSqlServer("Server=DESKTOP-79DNOTS\\SQL2022;Database=ModelTrainingData;Trusted_Connection=True;TrustServerCertificate=True");
        }

        public DbSet<TrainingData> TrainingData { get; set; }
    }
}
