using Microsoft.EntityFrameworkCore;

namespace DhlLesson09Bai2TuLam.Models
{
    public class DhlAppDbContext : DbContext
    {
        public DhlAppDbContext(DbContextOptions<DhlAppDbContext> options) : base(options)
        {
        }

        public DbSet<DhlCategory> DhlCategories { get; set; }
        public DbSet<DhlProduct> DhlProducts { get; set; }
        public DbSet<DhlBanner> DhlBanners { get; set; }
        public DbSet<DhlBlog> DhlBlogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // CATEGORY configuration
            modelBuilder.Entity<DhlCategory>(entity =>
            {
                entity.ToTable("CATEGORY");
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Name).IsUnique();
                entity.Property(e => e.Name).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Status).HasDefaultValue((byte)1);
                entity.Property(e => e.CreatedDate).HasColumnType("date").HasDefaultValueSql("CAST(GETDATE() AS date)");
                entity.Property(e => e.Image).HasMaxLength(100).IsUnicode(false);
                entity.Property(e => e.Description).HasMaxLength(350);
            });

            // PRODUCT configuration
            modelBuilder.Entity<DhlProduct>(entity =>
            {
                entity.ToTable("PRODUCT");
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Name).IsUnique();
                entity.Property(e => e.Name).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Price).IsRequired();
                entity.Property(e => e.salePrice).HasDefaultValue(0);
                entity.Property(e => e.Status).HasDefaultValue((byte)1);
                entity.Property(e => e.CreatedDate).HasColumnType("date").HasDefaultValueSql("CAST(GETDATE() AS date)");
                entity.Property(e => e.Image).HasMaxLength(100).IsUnicode(false);
                entity.Property(e => e.Description).HasMaxLength(350);

                entity.HasOne(p => p.Category)
                      .WithMany(c => c.DhlProducts)
                      .HasForeignKey(p => p.CategoryId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // BANNER configuration
            modelBuilder.Entity<DhlBanner>(entity =>
            {
                entity.ToTable("BANNER");
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Name).IsUnique();
                entity.Property(e => e.Name).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Status).HasDefaultValue((byte)1);
                entity.Property(e => e.Prioty).HasDefaultValue(0);
                entity.Property(e => e.Image).HasMaxLength(100).IsUnicode(false);
                entity.Property(e => e.Description).HasMaxLength(350);
            });

            // BLOG configuration
            modelBuilder.Entity<DhlBlog>(entity =>
            {
                entity.ToTable("BLOG");
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Name).IsUnique();
                entity.Property(e => e.Name).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Status).HasDefaultValue((byte)1);
                entity.Property(e => e.CreatedDate).HasColumnType("date").HasDefaultValueSql("CAST(GETDATE() AS date)");
                entity.Property(e => e.Image).HasMaxLength(100).IsUnicode(false);
                entity.Property(e => e.Description).HasMaxLength(350);
            });

            // Seed sample data
            modelBuilder.Entity<DhlCategory>().HasData(
                new DhlCategory { Id = 1, Name = "Điện thoại & Tablet", Status = 1, CreatedDate = new DateTime(2026, 1, 1), Image = "cat1.jpg", Description = "Các thiết bị di động thông minh" },
                new DhlCategory { Id = 2, Name = "Laptop & Máy tính", Status = 1, CreatedDate = new DateTime(2026, 1, 1), Image = "cat2.jpg", Description = "Máy tính xách tay và máy tính để bàn" },
                new DhlCategory { Id = 3, Name = "Phụ kiện công nghệ", Status = 1, CreatedDate = new DateTime(2026, 1, 1), Image = "cat3.jpg", Description = "Tai nghe, bàn phím, chuột, sạc cáp" }
            );

            modelBuilder.Entity<DhlProduct>().HasData(
                new DhlProduct { Id = 1, Name = "iPhone 15 Pro Max 256GB", Price = 29990000, salePrice = 28490000, Status = 1, CategoryId = 1, CreatedDate = new DateTime(2026, 1, 2), Image = "iphone15.jpg", Description = "Thiết kế titan cao cấp, chip A17 Pro mạnh mẽ" },
                new DhlProduct { Id = 2, Name = "Samsung Galaxy S24 Ultra", Price = 31990000, salePrice = 29990000, Status = 1, CategoryId = 1, CreatedDate = new DateTime(2026, 1, 2), Image = "s24.jpg", Description = "Trí tuệ nhân tạo Galaxy AI đỉnh cao" },
                new DhlProduct { Id = 3, Name = "MacBook Air M3 15 inch", Price = 32990000, salePrice = 30990000, Status = 1, CategoryId = 2, CreatedDate = new DateTime(2026, 1, 3), Image = "macbookm3.jpg", Description = "Màn hình Liquid Retina 15.3 inch, chip M3 nhanh vượt trội" },
                new DhlProduct { Id = 4, Name = "Tai nghe AirPods Pro 2 MagSafe", Price = 5990000, salePrice = 5490000, Status = 1, CategoryId = 3, CreatedDate = new DateTime(2026, 1, 4), Image = "airpods.jpg", Description = "Chống ồn chủ động gấp 2 lần thế hệ trước" }
            );

            modelBuilder.Entity<DhlBanner>().HasData(
                new DhlBanner { Id = 1, Name = "Khuyến mãi Tết 2026", Status = 1, Prioty = 1, Image = "banner1.jpg", Description = "Giảm giá lên đến 50% toàn bộ sản phẩm công nghệ" },
                new DhlBanner { Id = 2, Name = "Ra mắt sản phẩm mới", Status = 1, Prioty = 2, Image = "banner2.jpg", Description = "Đón đầu xu hướng công nghệ tương lai" }
            );

            modelBuilder.Entity<DhlBlog>().HasData(
                new DhlBlog { Id = 1, Name = "Đánh giá chi tiết hiệu năng iPhone 15 Pro Max", Status = 1, CreatedDate = new DateTime(2026, 1, 5), Image = "blog1.jpg", Description = "Bài viết phân tích chuyên sâu về camera và chip A17 Pro" },
                new DhlBlog { Id = 2, Name = "Top 5 laptop văn phòng đáng mua nhất năm 2026", Status = 1, CreatedDate = new DateTime(2026, 1, 6), Image = "blog2.jpg", Description = "Gợi ý các dòng laptop mỏng nhẹ, pin trâu phù hợp sinh viên và dân văn phòng" }
            );
        }
    }
}
