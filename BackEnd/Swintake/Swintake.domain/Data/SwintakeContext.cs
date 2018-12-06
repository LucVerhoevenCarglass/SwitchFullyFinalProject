using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Swintake.domain.Data
{
    public class SwintakeContext : DbContext
    {
        private readonly ILoggerFactory _loggerFactory;
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

            base.OnModelCreating(modelBuilder);
        }

    }

}
