using LightNovelService.Models;
using Microsoft.EntityFrameworkCore;

namespace LightNovelService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions opts) : base(opts)
        {
        }

        public DbSet<Author> Authors { get; set; } = null!;
    }
}