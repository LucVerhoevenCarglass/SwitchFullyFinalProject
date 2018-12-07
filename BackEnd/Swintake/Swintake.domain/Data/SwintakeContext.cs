using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Swintake.domain.Campaigns;
using Swintake.domain.Users;

namespace Swintake.domain.Data
{
    public partial class SwintakeContext : DbContext
    {
        private readonly ILoggerFactory _loggerFactory;

        public DbSet<User> Users { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }

        public SwintakeContext(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public SwintakeContext(DbContextOptions<SwintakeContext> options) : base(options)
        {
        }

        public SwintakeContext(DbContextOptions<SwintakeContext> options, ILoggerFactory loggerFactory) : base(options)
        {
            _loggerFactory = loggerFactory;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseLoggerFactory(_loggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .ToTable("Users")
                .HasKey(u => u.Id);

            modelBuilder.Entity<User>()
                .OwnsOne(u => u.UserSecurity, us =>
                {
                    us.Property(u => u.PasswordHashedAndSalted).HasColumnName("PasswordHashed");
                    us.Property(u => u.AppliedSalt).HasColumnName("AppliedSalt");
                });

            modelBuilder.Entity<Campaign>()
                .ToTable("Campaigns")
                .HasKey(campaign => campaign.Id);

            base.OnModelCreating(modelBuilder);

            SeedData(modelBuilder);
        }

       


    }

}
