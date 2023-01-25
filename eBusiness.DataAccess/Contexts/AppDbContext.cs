using eBusiness.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace eBusiness.DataAccess.Contexts;

public class AppDbContext:DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
	{
	}
	public DbSet<TeamMember> TeamMembers { get; set; } = null!;
}
