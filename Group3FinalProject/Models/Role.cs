using System.ComponentModel.DataAnnotations;

namespace Group3FinalProject.Models
{
	public class Role
	{
		public int RoleId { get; set; }
		[MaxLength(100)]
		public string RoleName { get; set; }
		public List<UserRole> UserRole { get; set; }
	}
}
