using Microsoft.EntityFrameworkCore;
using System;

namespace AccesoDatos
{
    public class LogContext : DbContext
    {
        public LogContext(DbContextOptions<LogContext> options) : base(options)
        {

        }

        public DbSet<LogServicio> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LogServicio>().ToTable("LOG_SERVICIO");
        }
    }
}
