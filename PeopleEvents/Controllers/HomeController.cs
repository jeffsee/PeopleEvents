using PeopleEvents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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