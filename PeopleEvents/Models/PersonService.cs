using PeopleEvents.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeopleEvents.Models
{
	/// <summary>
	/// Service for People
	/// </summary>
	public class PersonService
	{
		private PEContext db = new PEContext();

		/// <summary>
		/// Returns a list of people in the database
		/// </summary>
		/// <returns></returns>
		public List<Person> GetPeople()
		{
			return db.People.ToList();
		}

		/// <summary>
		/// Returns the specified person
		/// </summary>
		/// <param name="personID"></param>
		/// <returns></returns>
		public Person GetPerson(int personID)
		{
			return db.People.Find(personID);
		}
	}
}