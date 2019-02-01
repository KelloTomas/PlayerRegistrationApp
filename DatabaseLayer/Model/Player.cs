using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Model
{
	public class Player
	{
		[Key]
		public int Id { get; set; }
		public int PlaceOveral { get; set; }
		public int PlaceCategory { get; set; }
		public int Number { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string YearOfBirth { get; set; }
		public string Club { get; set; }
		public Category Category { get; set; }
		public DateTime Time { get; set; }
	}
}
