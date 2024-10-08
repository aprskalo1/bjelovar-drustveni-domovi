using BddAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BddAPI.Data;

public class BddDbContext(DbContextOptions<BddDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; init; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "server=.;Database=BjelovarDrustveniDomovi;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true");
    }
}