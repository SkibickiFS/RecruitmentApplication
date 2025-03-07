using System.Data.Entity;
using System.Data.SQLite;
using System.Data.Entity.Infrastructure;

namespace RecruitmentApplication.Models
{
    public class RecruitmentDbContext : DbContext
    {
        public RecruitmentDbContext() : base("name=RecruitmentDbContext")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasRequired(u => u.Role)
                .WithMany()
                .HasForeignKey(u => u.RoleId);

            modelBuilder.Entity<Question>()
                .Property(q => q.Text)
                .IsRequired()
                .HasMaxLength(500);

            modelBuilder.Entity<Answer>()
                .Property(a => a.AnswerText)
                .IsRequired()
                .HasMaxLength(500);

            modelBuilder.Entity<Role>()
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Role>()
                .HasMany(r => r.Permissions)
                .WithMany(p => p.Roles)
                .Map(m =>
                {
                    m.ToTable("RolePermissions");
                    m.MapLeftKey("RoleId");
                    m.MapRightKey("PermissionId");
                });

            modelBuilder.Entity<Permission>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100); 
        }
    }
}