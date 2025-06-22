using Microsoft.EntityFrameworkCore;

namespace MusicWebAPI
{
    public class MusicContext : DbContext
    {
        public MusicContext(DbContextOptions<MusicContext> options) : base(options)
        {}
        public DbSet<Track> Track { get; set; } // DbSet for Track entity
    }

    
}
