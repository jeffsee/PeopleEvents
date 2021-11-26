using System;
using System.ComponentModel.DataAnnotations;

namespace PeopleEvents.Models
{
	/// <summary>
	/// The model for a person
	/// </summary>
	public class Person
	{
		public int ID { get; set; }
		public string Name { get; set; }
		[Display(Name = "Date of Birth")]
		public DateTime DateOfBirth { get; set; }
		public string Gender { get; set; }
	}
}