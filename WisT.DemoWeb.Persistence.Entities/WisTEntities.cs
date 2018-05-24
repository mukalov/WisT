using System.Data.Entity;

namespace WisT.DemoWeb.Persistence.DataEntities
{

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
