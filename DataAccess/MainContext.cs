using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class MainContext : DbContext
    {
        public MainContext()
        {

        }

        public MainContext(DbContextOptions<MainContext> options) : base(options)
        {
        }
        public virtual DbSet<SYS_Users> SYS_Users { get; set; }
        public virtual DbSet<SYS_Logins> SYS_Logins { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<SYS_Logins>(entity =>
             {

                 // One to One Relation
                 entity.HasOne(d => d.Users)
                         .WithOne(p => p.Logins)
                         .HasForeignKey<SYS_Logins>(d => d.LoginId)
                         .OnDelete(DeleteBehavior.NoAction);

             });

        }


    }
}
