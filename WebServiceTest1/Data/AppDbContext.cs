using Microsoft.EntityFrameworkCore;

namespace WebServiceTest1.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<RequestData> RequestData { get; set; }
}