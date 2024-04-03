using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace TangerEcoWatch.Models
{
	public class Report
	{
		[Key]
		public int ReportId { get; set; } = 0;
		[Required]
		public string Location { get; set; } = "";
		public string? Description { get; set; }
		[Required]
		public string PhotoUrl { get; set; } = "";
		public string Status { get; set; } = "";
		[Required]
		public DateTime SubmissionDate { get; set; }
		[ForeignKey("UserId")]
		[NotMapped]
		public int? UserId { get; set; } = 0;
        

        [NotMapped]
        public User User { get; set; } = new User();

		public void SubmitReport(string location, string description, string photoUrl)
		{
			Location = location;
			Description = description;
			PhotoUrl = photoUrl;
			Status = "Submitted";
			SubmissionDate = DateTime.Now;
		}
		public void UpdateStatus(string newStatus)
		{
			Status = newStatus;
		}
	}
}
