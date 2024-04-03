using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TangerEcoWatch.Models;

namespace TangerEcoWatch.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
		public DbSet<TangerEcoWatch.Models.Report>? Report { get; set; }
		public DbSet<TangerEcoWatch.Models.Feedback>? Feedback { get; set; }
		public DbSet<TangerEcoWatch.Models.Notification>? Notification { get; set; }
		public DbSet<TangerEcoWatch.Models.EnvironmentalData>? EnvironmentalData { get; set; }
		public DbSet<TangerEcoWatch.Models.CleanUpEvent>? CleanUpEvent { get; set; }
		public DbSet<TangerEcoWatch.Models.Dashboard>? Dashboard { get; set; }

    }
}