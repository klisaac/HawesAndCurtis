using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HawesAndCurtis.Core.Entities.Base;
using HawesAndCurtis.Core.Entities;


namespace HawesAndCurtis.Infrastructure.Data
{
    public static class HawesAndCurtisModelBuilder
    {
        public static void ConfigureProductType(EntityTypeBuilder<ProductType> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("ProductType").HasKey(c => c.ProductTypeId);
            entityTypeBuilder.Property(c => c.ProductTypeId).ValueGeneratedOnAdd().UseIdentityColumn();
            entityTypeBuilder.Property(c => c.Name).IsRequired().HasMaxLength(100);
            entityTypeBuilder.Property(c => c.Description).HasMaxLength(100);
            AddAuditFields(entityTypeBuilder);
        }
        public static void ConfigureProduct(EntityTypeBuilder<Product> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("Product").Property(p => p.ProductId).ValueGeneratedOnAdd().UseIdentityColumn();
            entityTypeBuilder.HasKey(p => p.ProductId);
            entityTypeBuilder.Property(p => p.Code).IsRequired(true).HasMaxLength(100);
            entityTypeBuilder.HasIndex(p => p.Code).IsUnique();
            entityTypeBuilder.Property(p => p.Name).IsRequired(true).HasMaxLength(100);
            entityTypeBuilder.Property(p => p.Description);
            entityTypeBuilder.Property(p => p.ImageFile).HasMaxLength(200);
            entityTypeBuilder.Property(p => p.Price).HasColumnType("decimal(16, 3)");
            entityTypeBuilder.Property(p => p.ProductTypeId);
            AddAuditFields(entityTypeBuilder);
        }

        public static void ConfigureProductRecommendation(EntityTypeBuilder<ProductRecommendation> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("ProductRecommendation").Property(r => r.ProductRecommendationId).ValueGeneratedOnAdd().UseIdentityColumn();
            entityTypeBuilder.HasKey(r => r.ProductRecommendationId);
            entityTypeBuilder.Property(r => r.ProductId).IsRequired();
            entityTypeBuilder.Property(r => r.RecommendedProductId).IsRequired();
            entityTypeBuilder.HasOne(p => p.Product).WithMany(r => r.ProductRecommendations).OnDelete(DeleteBehavior.Restrict);
            AddAuditFields(entityTypeBuilder);
        }

        public static void ConfigureProductSpecificationn(EntityTypeBuilder<ProductSpecification> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("ProductSpecification").Property(ps => ps.ProductSpecificationId).ValueGeneratedOnAdd().UseIdentityColumn();
            entityTypeBuilder.HasKey(ps => ps.ProductSpecificationId);
            entityTypeBuilder.Property(ps => ps.ProductId).IsRequired();
            entityTypeBuilder.Property(ps => ps.Specification);
            entityTypeBuilder.HasOne(p => p.Product).WithMany(s => s.ProductSpecifications).OnDelete(DeleteBehavior.Restrict);
            AddAuditFields(entityTypeBuilder);
        }

        public static void ConfigureUser(EntityTypeBuilder<User> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("User").Property(u => u.UserId).ValueGeneratedOnAdd().UseIdentityColumn();
            entityTypeBuilder.HasKey(u => u.UserId);
            entityTypeBuilder.Property(u => u.UserName).IsRequired().HasMaxLength(50);
            entityTypeBuilder.HasIndex(u => u.UserName).IsUnique();
            entityTypeBuilder.Property(u => u.PasswordHash).HasColumnType("varbinary(max)").IsRequired();
            entityTypeBuilder.Property(u => u.PasswordSalt).HasColumnType("varbinary(max)").IsRequired();
            AddAuditFields(entityTypeBuilder);
        }

        private static void AddAuditFields<T>(EntityTypeBuilder<T> entityTypeBuilder) where T : AuditEntity
        {
            entityTypeBuilder.Property(ae => ae.IsDeleted).IsRequired(true);
            entityTypeBuilder.Property(ae => ae.CreatedBy).IsRequired(true).HasMaxLength(50);
            entityTypeBuilder.Property(ae => ae.CreatedDate).IsRequired(true);
            entityTypeBuilder.Property(ae => ae.LastModifiedBy).IsRequired(false).HasMaxLength(50);
            entityTypeBuilder.Property(ae => ae.LastModifiedDate).IsRequired(false);
        }
    }
}
