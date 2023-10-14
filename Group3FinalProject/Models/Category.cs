using System.ComponentModel.DataAnnotations.Schema;

namespace Group3FinalProject.Models
{
	public class Category
	{
		public int CategoryId { get; set; }
		public string Name { get; set; }
		
		public List<Course> Course { get; set; }
	}
}
