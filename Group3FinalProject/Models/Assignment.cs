using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group3FinalProject.Models
{
	public class Assignment
	{
        [Key]
        public int AssignmentId { get; set; }
		[MaxLength(150)]
		public string Title { get; set; }
		[MaxLength(500)]
		public string Description { get; set; }
		public DateTime DueDate { get; set; }
		[ForeignKey("Course")]
		public int CourseId { get; set; }
		public Course Course { get; set; }

	}
}
