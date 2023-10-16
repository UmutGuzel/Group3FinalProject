using Group3FinalProject.Controllers;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group3FinalProject.Models
{
	public class Enrollment
	{
		[Key]
		public int EnrollmentId { get; set; }
		public DateTime EnrollmentDate { get; set; }

		[ForeignKey("IdentityUser")]
		public string? Id { get; set; }
		public IdentityUser? User { get; set; }
		[ForeignKey("Course")]
		public int? CourseId { get; set; }
		public Course? Course { get; set; }
	}
}
