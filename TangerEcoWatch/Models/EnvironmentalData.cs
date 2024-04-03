using System.ComponentModel.DataAnnotations;
namespace TangerEcoWatch.Models
{
	public class EnvironmentalData
	{
		[Key]
		public int DataId { get; set; } = 0;
		[Required]
		public string Type { get; set; } = "";
		[Required]
		public float Value { get; set; } = 0;
		[Required]
		public DateTime TimeStamp { get; set; } = new DateTime();
		[Required]
		public string Location { get; set; } = "";
		public void CollectData()
		{
			Console.WriteLine("Data collected successfully.");
		}

		public void AnalyzeData()
		{
			Console.WriteLine("Data analyzed successfully.");
		}
	}
}
