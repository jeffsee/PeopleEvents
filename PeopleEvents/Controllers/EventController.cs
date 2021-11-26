using PeopleEvents.DAL;
using PeopleEvents.Models;
using System;
using System.Linq;
using System.Web.Http;

namespace PeopleEvents.Controllers
{
    /// <summary>
    /// An API for events - I only really use the initial api/Event for testing to create random events to show up
    /// But added the rest for completeness
    /// </summary>
	public class EventController : ApiController
    {
        private PEContext db = new PEContext();

        /// <summary>
        /// Randomly generates an event and adds it to the database (and attempt to reconcile with a person - which it should always do as we're using existing people's data)
        /// Used to simulate obtaining data from an external Events source
        /// In a real world scenario, this would probably be a separate project which would poll the external source, import new events, then attempt to reconcile them
        /// </summary>
        /// <returns>The new event</returns>
        public IHttpActionResult Get()
        {
            // First get a random person for the event
            var numberOfPeople = db.People.Count();
            var random = new Random();
            var randomPersonID = random.Next(1, numberOfPeople + 1);
            var person = db.People.Find(randomPersonID);

            // Create the event with random details
            var newEvent = new Event() { PersonName = person.Name, DateOfBirth = person.DateOfBirth, EventDateTime = new DateTime(random.Next(1990, 2022), random.Next(1, 13), random.Next(1, 29)), EventDescription = "Random New Event #" + random.Next(1, 1000000) };

            // Save the event
            db.Events.Add(newEvent);
            db.SaveChanges();

            // Reconcile the event to a person
            EventService es = new EventService();
            es.ReconcileEventToPerson(newEvent);

            return Ok(newEvent);
        }

        // GET api/Event/EventID
        public IHttpActionResult Get(int id)
        {
            var gottenEvent = db.Events.Where(e => e.ID == id).FirstOrDefault();
            if (gottenEvent != null)
            {
                return Ok(gottenEvent);
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/Event
        public void Post([FromBody]Event newEvent)
		{
            // Add the event to the database
            db.Events.Add(newEvent);
            db.SaveChanges();

            // Attempt to reconcile it
            EventService es = new EventService();
            es.ReconcileEventToPerson(newEvent);
		}

        // DELETE api/Event
        public void Delete(int id)
		{
            var eventToDelete = db.Events.Find(id);
            db.Events.Remove(eventToDelete);
            db.SaveChanges();
		}
    }
}