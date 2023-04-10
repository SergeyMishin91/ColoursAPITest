using ColoursAPITest.Models;
using Microsoft.EntityFrameworkCore;

namespace ColoursAPITest.Data
{
    public class ColourContext : DbContext
    {
        private readonly ILogger<ColourContext> _logger;

        public ColourContext(DbContextOptions<ColourContext> options, ILogger<ColourContext> logger) : base(options)
        {
            _logger = logger;
            _logger.LogInformation("Before");
            Database.EnsureCreated();
            _logger.LogInformation("After");

        }

        public DbSet<Colour> ColourItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _logger.LogInformation("CreTING MODEL");
            modelBuilder.Entity<Colour>().ToTable("Colour");
            _logger.LogInformation("Created MODEL");
        }
    }
}
