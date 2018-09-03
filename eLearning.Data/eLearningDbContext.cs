using eLearning.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace eLearning.Data
{
    public class eLearningDbContext : DbContext
    {
        private IConfigurationRoot _config;

        public eLearningDbContext(DbContextOptions<eLearningDbContext> options,
            IConfigurationRoot config)
            : base(options)
        {
            _config = config;
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config["ConnectionStrings:eLearningDbConnectionString"]);
        }
    }
}
