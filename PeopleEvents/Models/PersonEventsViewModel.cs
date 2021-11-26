using System.Collections.Generic;

namespace PeopleEvents.Models
{
	/// <summary>
	/// The View Model for the People - Event view
	/// </summary>
	public class PersonEventsViewModel
	{
		public int PersonID { get; set; }
		public List<Event> PersonEvents { get; set; }
	}
}