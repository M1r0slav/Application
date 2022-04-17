using Infrastructure.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<Band> Bands { get; set; }
        public DbSet<BandStyle> BandStyles { get; set; }
        public DbSet<MusicStyle> MusicStyles { get; set; }
        public DbSet<Concert> Concerts { get; set; }
        public DbSet<ConcertDate> ConcertDates { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BandStyle>().HasKey(x => new { x.BandId, x.MusicStyleId });
            base.OnModelCreating(builder);
        }
    }
}
