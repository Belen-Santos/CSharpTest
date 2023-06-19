using BelenSA.Models;
using Microsoft.EntityFrameworkCore;

namespace BelenSA.Data
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ReasonSignUp> ReasonsForSigningUp { get; set; }
        public virtual DbSet<Subscriber> Subscribers { get; set; }
        public virtual DbSet<SubscriberReasons> SubscribersReasons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Establishing the many to many relation between Subscriber and ReasonSignUp
            modelBuilder.Entity<SubscriberReasons>(entity =>
            {
                entity.HasOne(r => r.ReasonSignUp)
                .WithMany(x => x.SubscriberReasons)
                .HasForeignKey(r => r.ReasonSignUpId)
                .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(s => s.Subscriber)
                .WithMany(x => x.SubscriberReasons)
                .HasForeignKey(s => s.SubscriberId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });


        }
    }
}
