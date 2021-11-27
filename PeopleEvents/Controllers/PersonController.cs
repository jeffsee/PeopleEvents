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

        public ActionResult Edit(int id)
		{
            Person personToEdit;

            if (id == 0)
			{
                personToEdit = new Person();
                personToEdit.DateOfBirth = new System.DateTime(2000, 1, 1);
			}
            else
			{
                PersonService ps = new PersonService();
                personToEdit = ps.GetPerson(id);
            }

            return View(personToEdit);
		}

        [HttpPost]
        public ActionResult Index(Person person)
		{
            if (ModelState.IsValid)
            {
                PersonService ps = new PersonService();
                int personID = ps.SavePerson(person);

                return RedirectToAction("View", new { id = personID });
            }
            else
			{
                return RedirectToAction("Edit", new { id = person.ID });
			}
		}
    }
}