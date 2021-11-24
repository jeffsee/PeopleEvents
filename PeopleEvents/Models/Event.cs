using System;

namespace PeopleEvents.Models
{
	/// <summary>
	/// Model for an Event
	/// </summary>
	public class Event
	{
		public int ID { get; set; }
		public string PersonName { get; set; }
		public DateTime DateOfBirth { get; set; }
		public DateTime EventDateTime { get; set; }
		public string EventDescription { get; set; }
	}
}