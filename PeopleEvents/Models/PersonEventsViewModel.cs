using System.Collections.Generic;

namespace PeopleEvents.Models
{
	public class PersonEventsViewModel
	{
		public int PersonID { get; set; }
		public List<Event> PersonEvents { get; set; }
	}
}