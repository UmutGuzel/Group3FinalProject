﻿using Group3FinalProject.Controllers;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group3FinalProject.Models
{
	public class Enrollment
	{
		public int EnrollmentId { get; set; }
		public DateTime EnrollmentDate { get; set; }

		[ForeignKey("User")]
		public int UserId { get; set; }
		public User User { get; set; }
		[ForeignKey("Course")]
		public int CourseId { get; set; }
		public Course Course { get; set; }
	}
}
