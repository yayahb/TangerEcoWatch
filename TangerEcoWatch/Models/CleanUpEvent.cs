using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TangerEcoWatch.Models
{
	public class CleanUpEvent
	{
		[Key]
		public int EventId { get; set; } = 0;
		[Required]
		public string Name { get; set; } = "";
		[Required]
		public string Location { get; set; } = "";
		[Required]
		public DateTime Date { get; set; } = new DateTime();
		[ForeignKey("UserId")]
        [NotMapped]
        public int UserId { get; set; } = 0;
        [NotMapped]
        public User User { get; set; } = new User();
		[NotMapped]
		public List<int> Participants { get; set; } = new List<int>();

		public CleanUpEvent()
		{
			Participants = new List<int>();
		}

		public void AddParticipant(int participantId)
		{
			if (!Participants.Contains(participantId))
			{
				Participants.Add(participantId);
				Console.WriteLine($"Participant with ID {participantId} added to the event '{Name}'.");
			}
			else
			{
				Console.WriteLine($"Participant with ID {participantId} is already part of the event '{Name}'.");
			}
		}

		public void RemoveParticipant(int participantId)
		{
			if (Participants.Contains(participantId))
			{
				Participants.Remove(participantId);
				Console.WriteLine($"Participant with ID {participantId} removed from the event '{Name}'.");
			}
			else
			{
				Console.WriteLine($"Participant with ID {participantId} is not part of the event '{Name}'.");
			}
		}

	}
}
