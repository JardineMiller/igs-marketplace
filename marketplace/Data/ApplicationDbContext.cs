using System;
using System.Threading;
using System.Threading.Tasks;
using marketplace.Data.Models;
using marketplace.Data.Models.Base;
using Microsoft.EntityFrameworkCore;

namespace marketplace.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            base.OnModelCreating(builder);
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            ApplyAuditInformation();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = new CancellationToken())
        {
            ApplyAuditInformation();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void ApplyAuditInformation()
        {
            var auditEntries = this.ChangeTracker.Entries<IAuditEntity>();

            foreach (var entityEntry in auditEntries)
            {
                switch (entityEntry.State)
                {
                    case EntityState.Added:
                        entityEntry.Entity.CreatedOn = DateTimeOffset.UtcNow;
                        break;

                    case EntityState.Modified:
                        entityEntry.Entity.ModifiedOn = DateTimeOffset.UtcNow;
                        break;

                    case EntityState.Deleted:
                        if (entityEntry.Entity is IDeleteableEntity deletableEntity)
                        {
                            deletableEntity.DeletedOn = DateTimeOffset.UtcNow;
                            deletableEntity.IsDeleted = true;

                            entityEntry.State = EntityState.Modified;
                        }

                        break;
                }
            }
        }
    }
}
