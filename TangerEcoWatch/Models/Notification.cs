using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TangerEcoWatch.Models
{
	public class Notification
	{
		[Key]
		public int NotificationId { get; set; } = 0;
		[ForeignKey("UserId")]
		public int UserId { get; set; } = 0;
		[Required]
		public string Message { get; set; } = "";
		[Required]
		public DateTime Date { get; set; } = new DateTime();
		public Notification(int userId, string message)
		{
			UserId = userId;
			Message = message;
			Date = DateTime.Now;
		}

		public void SendNotification()
		{
			Console.WriteLine($"Notification sent to User {UserId} on {Date}: {Message}");
		}
	}
}
