using Microsoft.EntityFrameworkCore;
using Server.Entities;

namespace Server.Data;

public class ServerDbContext : DbContext
{
  public ServerDbContext(DbContextOptions<ServerDbContext> options) : base(options)
  {
  }

  public DbSet<User> Users { get; set; }
}