using PeopleEvents.DAL;
using System.Collections.Generic;
using System.Linq;

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
		public PersonEventsViewModel GetEventsForPerson(int personID)
		{
			var pevm = new PersonEventsViewModel();
			pevm.PersonID = personID;
			var listOfEventIds = db.PersonEvents.Where(pe => pe.PersonID == personID).Select(pe => pe.EventID).ToList();
			pevm.PersonEvents = db.Events.Where(e => listOfEventIds.Contains(e.ID)).OrderBy(e => e.EventDateTime).ToList();

			return pevm;
		}

		/// <summary>
		/// Attempts to reconcile an event to a person based off name and date of birth
		/// </summary>
		/// <param name="eventToRec"></param>
		public void ReconcileEventToPerson(Event eventToRec)
		{
			var matchedPerson = db.People.Where(p => p.Name == eventToRec.PersonName && p.DateOfBirth == eventToRec.DateOfBirth).FirstOrDefault();

			if (matchedPerson != null)
			{
				var newPersonEvent = new PersonEvent() { EventID = eventToRec.ID, PersonID = matchedPerson.ID };
				db.PersonEvents.Add(newPersonEvent);
				db.SaveChanges();
			}
		}

		/// <summary>
		/// Removes the person -> event link for the given event ID
		/// </summary>
		/// <param name="eventID"></param>
		public void UnlinkEvent(int personID, int eventID)
		{
			var linkToUnlink = db.PersonEvents.Where(pe => pe.PersonID == personID && pe.EventID == eventID).FirstOrDefault();
			if (linkToUnlink != null)
			{
				db.PersonEvents.Remove(linkToUnlink);
				db.SaveChanges();
			}
		}
	}
}