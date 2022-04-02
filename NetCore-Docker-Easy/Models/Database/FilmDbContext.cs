using Microsoft.EntityFrameworkCore;

namespace NetCore_Docker_Easy.Models
{
    public class FilmDbContext : DbContext
    {
        public FilmDbContext(DbContextOptions<FilmDbContext> options) : base(options) { }

        public DbSet<Film> Film { get; set; }
    }
}