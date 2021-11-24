using System;

namespace PeopleEvents.Models
{
	/// <summary>
	/// The model for a person
	/// </summary>
	public class Person
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public DateTime DateOfBirth { get; set; }
		public string Gender { get; set; }
	}
}