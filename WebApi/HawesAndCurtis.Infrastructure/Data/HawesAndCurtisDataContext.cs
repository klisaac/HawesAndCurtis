using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using HawesAndCurtis.Core.Entities;
using HawesAndCurtis.Core.Entities.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HawesAndCurtis.Infrastructure.Data
{
    public class HawesAndCurtisDataContext : DbContext
    {
        private IDbContextTransaction _currentTransaction;
        //private IConfiguration _configuration;
        //private readonly ICurrentUser _currentUser;

        public HawesAndCurtisDataContext()
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }

        public HawesAndCurtisDataContext(DbContextOptions<HawesAndCurtisDataContext> options)
            : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductRecommendation> ProductRecommendations { get; set; }
        public DbSet<ProductSpecification> ProductSpecifications { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server database
            //options.UseSqlServer(_configuration.GetConnectionString(Constants.DbConnectionStringKey));
            //options.UseSqlServer("Server=localhost;User Id=sa;password=Dev@2019;Database=AspNet5Dev");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductType>(HawesAndCurtisModelBuilder.ConfigureProductType);
            modelBuilder.Entity<Product>(HawesAndCurtisModelBuilder.ConfigureProduct);
            modelBuilder.Entity<ProductRecommendation>(HawesAndCurtisModelBuilder.ConfigureProductRecommendation);
            modelBuilder.Entity<ProductSpecification>(HawesAndCurtisModelBuilder.ConfigureProductSpecificationn);
            modelBuilder.Entity<User>(HawesAndCurtisModelBuilder.ConfigureUser);
            //ConfigureUser(modelBuilder.Entity<User>());
        }

        //private void ConfigureUser<T>(EntityTypeBuilder<T> entityTypeBuilder) where T : AuditEntity
        //{
        //    //entityTypeBuilder.ToTable("User").Property(u => u.UserId).ValueGeneratedOnAdd().UseIdentityColumn();
        //    //entityTypeBuilder.Property(u => u.UserName).IsRequired();
        //    //entityTypeBuilder.HasIndex(u => u.UserName).IsUnique();
        //    //entityTypeBuilder.Property<byte[]>("PasswordHash").HasColumnType("varbinary(max)");
        //    //entityTypeBuilder.Property<byte[]>("PasswordSalt").HasColumnType("varbinary(max)");
        //    entityTypeBuilder.Property(d => d.IsDeleted).IsRequired(true);
        //    entityTypeBuilder.Property(d => d.CreatedBy).IsRequired(true);
        //    entityTypeBuilder.Property(d => d.CreatedDate).IsRequired(true);
        //    entityTypeBuilder.Property(d => d.LastModifiedBy).IsRequired(false);
        //    entityTypeBuilder.Property(d => d.LastModifiedDate).IsRequired(false);
        //}

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.IsDeleted = false;
                        //entry.Entity.CreatedBy = _currentUser.UserName;
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        //entry.Entity.LastModifiedBy = _currentUser.UserName;
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public async Task BeginTransactionAsync()
        {
            _currentTransaction = _currentTransaction ?? await Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            try
            {
                //await SaveChangesAsync();
                await _currentTransaction?.CommitAsync();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

    }
}
