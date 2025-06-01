using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Entities
{
	public class Genre
	{
		public int Id { get; set; }

		[Required]
		public required string Name { get; set; }

		//public List<Movie> Movies { get; set; }
	}
}
