using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace TangerEcoWatch.Models
{
	public class Dashboard
	{
        [Key]
        public int DashboardId { get; set; }
        public int NumberOfReports { get; set; } = 0;
		public int CleanupEvents { get; private set; }
		public int ActiveUsers { get; set; } = 0;
		public void UpdateDashboard(int reports, int cleanupEvents, int activeUsers)
		{
			NumberOfReports = reports;
			CleanupEvents = cleanupEvents;
			ActiveUsers = activeUsers;
		}
	}
}
