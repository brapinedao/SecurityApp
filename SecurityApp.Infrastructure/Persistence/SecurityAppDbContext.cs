
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SecurityApp.Domain.Common;

namespace SecurityApp.Infrastructure.Persistence
{
    public class SecurityAppDbContext : DbContext
    {
        public SecurityAppDbContext(DbContextOptions<SecurityAppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var item in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(BaseDomain).IsAssignableFrom(item.ClrType))
                {
                    modelBuilder.Entity(item.ClrType, x => x.HasKey(nameof(BaseDomain.Id)).IsClustered());
                    modelBuilder.Entity(item.ClrType, x => x.Property(nameof(BaseDomain.Id))
                    .IsRequired()
                    .ValueGeneratedOnAdd()
                    .HasDefaultValueSql("newid()"));
                }
            }
            base.OnModelCreating(modelBuilder);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            builder.Properties<DateOnly>()
                .HaveConversion<DateOnlyConverter>()
                .HaveColumnType("date");
        }

        public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
        {
            public DateOnlyConverter() : base(
                d => d.ToDateTime(TimeOnly.MinValue),
                d => DateOnly.FromDateTime(d))
            { }
        }
    }
}
