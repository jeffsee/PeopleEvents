using PeopleEvents.Models;
using System.Web.Mvc;

namespace PeopleEvents.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			PersonService ps = new PersonService();
			return View(ps.GetPeople());
		}
	}
}