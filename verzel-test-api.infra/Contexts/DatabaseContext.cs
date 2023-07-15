using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using verzel_test_api.domain.Models;

namespace verzel_test_api.infra.Contexts
{
    public class DatabaseContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DatabaseContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(_configuration.GetConnectionString("DBConnection"));

        public DbSet<User> Users { get; set; }
    }
}