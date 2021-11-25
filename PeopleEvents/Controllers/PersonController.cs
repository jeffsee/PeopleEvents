using PeopleEvents.Models;
using System.Web.Mvc;

namespace PeopleEvents.Controllers
{
	public class PersonController : Controller
    {
        // GET: Person
        public ActionResult View(int id)
        {
            PersonService ps = new PersonService();
            return View(ps.GetPerson(id));
        }

        public ActionResult EventView(int id)
		{
            EventService es = new EventService();
            return PartialView(es.GetEventsForPerson(id));
		}

        [Route("Person/UnlinkEvent/{personID}/{eventID}")]
        public ActionResult UnlinkEvent(int personID, int eventID)
		{
            EventService es = new EventService();
            es.UnlinkEvent(personID, eventID);
            return RedirectToAction("View", new { id = personID });
        }
    }
}