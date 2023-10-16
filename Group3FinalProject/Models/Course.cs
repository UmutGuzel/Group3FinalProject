using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group3FinalProject.Models
{
	public class Course
	{
        [Key]
        public int CourseId { get; set; }
		[MaxLength(150)]
		public string Title { get; set; }
		[MaxLength(500)]
		public string Description { get; set; }
		
		public int EnrollmentCount { get; set; }
		public string ImageUrl { get; set; }

		[ForeignKey("Category")]
		public int? CategoryId { get; set; }
		public Category? Category { get; set; }

		

		public List<Enrollment>? Enrollment { get; set; }
		public List<Assignment>? Assignment { get; set; }


	}
}
