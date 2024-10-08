using BddAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BddAPI.Data;

public class BddDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "server=.;Database=BjelovarDrustveniDomovi;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true");
    }
}