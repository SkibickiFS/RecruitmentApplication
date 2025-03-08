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
        public DbSet<Position> Positions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasRequired(u => u.Role)
                .WithMany()
                .HasForeignKey(u => u.RoleId);

            modelBuilder.Entity<User>()
                .HasOptional(u => u.Position)
                .WithMany(p => p.Users)
                .HasForeignKey(u => u.PositionId);

            modelBuilder.Entity<Question>()
                .Property(q => q.Text)
                .IsRequired()
                .HasMaxLength(4000);

            modelBuilder.Entity<Question>()
                .HasRequired(q => q.Position)
                .WithMany(p => p.Questions)
                .HasForeignKey(q => q.PositionId);

            modelBuilder.Entity<Question>()
                .HasMany(q => q.Answers)
                .WithRequired(a => a.Question)
                .HasForeignKey(a => a.QuestionId);

            modelBuilder.Entity<Answer>()
                .Property(a => a.AnswerText)
                .IsRequired()
                .HasMaxLength(8000);

            modelBuilder.Entity<Answer>()
                .HasRequired(a => a.User)
                .WithMany(u => u.Answers)
                .HasForeignKey(a => a.UserId);

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