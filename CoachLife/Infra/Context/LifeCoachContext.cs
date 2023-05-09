using CoachLife.Domain.Models;
using CoachLife.Infra.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace CoachLife.Infra.Context
{
    [ExcludeFromCodeCoverage]
    public class LifeCoachContext : DbContext
    {
        public DbSet<User> User { get; set; }

        public LifeCoachContext(DbContextOptions<LifeCoachContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LifeCoachContext).Assembly);
            modelBuilder.ApplyGlobalFilters<ISoftDeleteEntity>(e => e.DeletedAt == null);

            base.OnModelCreating(modelBuilder);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
        public override int SaveChanges()
        {
            UpdateAuditDates();

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(
            bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            UpdateAuditDates();

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void UpdateAuditDates()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.CurrentValues[nameof(Entity.CreatedAt)] = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.CurrentValues[nameof(Entity.UpdatedAt)] = DateTime.UtcNow;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.CurrentValues[nameof(Entity.DeletedAt)] = DateTime.UtcNow;
                        break;
                }
            }
        }
    }
}
