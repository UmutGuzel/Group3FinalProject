using System.ComponentModel.DataAnnotations;

namespace Group3FinalProject.Models
{
	public class User
	{
		public int UserId { get; set; }
		[MaxLength(50)]
		public string Username { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		[MaxLength(20)]
		public string FirstName { get; set; }
		[MaxLength(20)]
		public string LastName { get; set; }

		public List<UserRole> UserRole { get; set; }
		public List<Course> Course { get; set; }
		public List<Enrollment> Enrollment { get; set; }

	}
}
