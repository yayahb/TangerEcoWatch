using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TangerEcoWatch.Models
{
	public class Feedback
	{
		[Key]
		public int FeedbackId { get; set; } = 0;
		[ForeignKey("UserId")]
		public int UserId { get; set; } = 0;
		public string Text { get; set; } = "";
		public DateTime SubmissionDate { get; set; } = new DateTime();
		public Feedback(int feedbackId, int userId, string text, DateTime submissionDate)
		{
			FeedbackId = feedbackId;
			UserId = userId;
			Text = text;
			SubmissionDate = DateTime.Now;
		}

		public void SubmitFeedback()
		{
			Console.WriteLine("Feedback submitted successfully.");
		}
	}
}
