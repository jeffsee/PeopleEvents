using PeopleEvents.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeopleEvents.Models
{
	/// <summary>
	/// Service for Events
	/// </summary>
	public class EventService
	{
		private PEContext db = new PEContext();

		/// <summary>
		/// Returns all events associated with a person
		/// </summary>
		/// <param name="personID"></param>
		/// <returns></returns>
		public List<Event> GetEventsForPerson(int personID)
		{
			var listOfEventIds = db.PersonEvents.Where(pe => pe.PersonID == personID).Select(pe => pe.EventID).ToList();
			return db.Events.Where(e => listOfEventIds.Contains(e.ID)).ToList();
		}
	}
}