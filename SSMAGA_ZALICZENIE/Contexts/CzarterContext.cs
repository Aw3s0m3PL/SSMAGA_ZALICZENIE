using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Hosting;
using Microsoft.Graph.ExternalConnectors;
using SSMAGA_ZALICZENIE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using TinyHelpers.EntityFrameworkCore.Extensions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SSMAGA_ZALICZENIE.Contexts
{
    public class CzarterContext : DbContext
    {
        public DbSet<RezerwacjeModel> Rezerwacje { get; set; }
        public DbSet<OfertaModel> Oferta { get; set; }
        public DbSet<AdminModel> Users { get; set; }

        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            builder.Properties<DateOnly>()
            .HaveConversion<DateOnlyConverter>()
                .HaveColumnType("date");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OfertaModel>()
                .HasMany(c => c.Rezerwacje)
                .WithOne(e => e.Oferta)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptions)
        {
            var cs = @"Data Source=AS_E7470;Initial Catalog=CzarterBD;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False;MultiSubnetFailover=False";
            dbContextOptions.UseSqlServer(cs);
        }
    }
}