using Microsoft.EntityFrameworkCore;
using API.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace API.Data
{
    public class DataContext: IdentityDbContext<AppUser, AppRole, int,
                IdentityUserClaim<int>, AppUserRole, IdentityUserLogin<int>,
                IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DataContext(DbContextOptions options) :base(options)
        {

        }

            // public DbSet<AppUser> Users { get; set; }
        public DbSet<UserLike> Likes { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Group> Groups { get; set; }

        public DbSet Name { get; set; }






      protected override void OnModelCreating(ModelBuilder builder)
      {
          base.OnModelCreating(builder);

          builder.Entity<AppUser>()
         .HasMany(ur => ur.UserRoles)
         .WithOne(u=> u.User)
         .HasForeignKey(ur => ur.UserId)
         .IsRequired();

          builder.Entity<AppRole>()
         .HasMany(ur => ur.UserRoles)
         .WithOne(u=> u.Role)
         .HasForeignKey(ur => ur.RoleId)
         .IsRequired();


          builder.Entity<UserLike>()
          .HasKey(k => new  {k.SourceUserId, k.LikedUserId});

          builder.Entity<UserLike>()
          .HasOne(s => s.SourceUser)
          .WithMany(l => l.LikedUsers)
          .HasForeignKey(s => s.SourceUserId)
          .OnDelete(DeleteBehavior.Cascade);


          builder.Entity<UserLike>()
          .HasOne(s => s.LikedUser)
          .WithMany(l => l.LikedByUsers)
          .HasForeignKey(s => s.LikedUserId)
          .OnDelete(DeleteBehavior.Cascade);

          builder.Entity<Message>()
          .HasOne(u => u.Recipient)
          .WithMany(m => m.MessageReceived)
          .OnDelete(DeleteBehavior.Restrict);

          builder.Entity<Message>()
          .HasOne(u => u.Sender)
          .WithMany(m => m.MessageSent)
          .OnDelete(DeleteBehavior.Restrict);

      }
    }
}