using BK.Entities;
using Microsoft.EntityFrameworkCore;

namespace BK.Dal;

public class BKDbContext : DbContext
{
    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<Comment> Comments { get; set; }
    public virtual DbSet<Post> Posts { get; set; }
    public virtual DbSet<Tag> Tags { get; set; }
    public virtual DbSet<User> Users { get; set; }
    
    
    public BKDbContext(DbContextOptions<BKDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
        });
        
        modelBuilder.Entity<Comment>(entity =>
        {
            entity.ToTable("Comment");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Text).IsRequired();
            entity.HasOne(e => e.Post).WithMany(e => e.Comments).HasForeignKey(e => e.Id).OnDelete(DeleteBehavior.NoAction);
            entity.HasOne(e => e.User).WithMany(e => e.Comments).HasForeignKey(e => e.Id).OnDelete(DeleteBehavior.NoAction);
        });
        
        modelBuilder.Entity<Post>(entity =>
        {
            entity.ToTable("Post");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Title).IsRequired();
            entity.Property(e => e.Content).IsRequired();
            entity.Property(e => e.Date).IsRequired();
            entity.HasOne(e => e.Author).WithMany(e => e.Posts).HasForeignKey(e => e.Id).OnDelete(DeleteBehavior.NoAction);
        });
        
        modelBuilder.Entity<Tag>(entity =>
        {
            entity.ToTable("Tag");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
        });
        
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Pseudo).IsRequired();
            entity.Property(e => e.Password).IsRequired();
            entity.Property(e => e.EmailAdress).IsRequired();
            entity.HasOne(e => e.Role).WithMany(e => e.Users).HasForeignKey(e => e.Id).OnDelete(DeleteBehavior.NoAction);
        });
        
        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
        });
    }
}