using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace TangerEcoWatch.Models
{
	[Keyless]
	
	public class User : IdentityUser
	{

		public string Name { get; set; } = "";
		public string Role { get; set; } = "";
		public string Location { get; set; } = "";
	}
}
