using DndNear.API.Models;

using Microsoft.EntityFrameworkCore;

namespace DndNear.API.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        #region Consts & Static
        #endregion Consts & Static

        #region Fields & Properties

        public DbSet<User> Users { get; set; }

        #endregion Fields & Properties

        #region Constructors
        #endregion Constructors

        #region Methods

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure your entities here
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Username).IsUnique();
                entity.HasIndex(e => e.Email).IsUnique();

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.Property(e => e.Name)
                    .HasMaxLength(100);

                entity.Property(e => e.CreationDate)
                    .IsRequired();
            });
        }
        
        #endregion Methods
    }
}
