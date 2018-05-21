namespace WisT.DemoWeb.Persistence.DataEntities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class WisTEntities : DbContext
    {
        public WisTEntities()
            : base("name=WisTEntities")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<WisTEntities, Migrations.Configuration>());
        }

        public virtual DbSet<UserImage> UserImages { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserImages)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
