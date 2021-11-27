using PeopleEvents.DAL;
using System.Collections.Generic;
using System.Linq;

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

		/// <summary>
		/// Attempts to save the given person
		/// </summary>
		/// <param name="person"></param>
		/// <returns>The ID of the person saved</returns>
		public int SavePerson(Person person)
		{
			// ID = 0, assume it's a new person and save it
			if (person.ID == 0)
			{
				var newPerson = new Person
				{
					Name = person.Name,
					DateOfBirth = person.DateOfBirth,
					Gender = person.Gender
				};
				db.People.Add(newPerson);
				db.SaveChanges();

				return newPerson.ID;
			}
			else
			{
				var existingPerson = db.People.Find(person.ID);
				if (existingPerson != null)
				{
					existingPerson.Name = person.Name;
					existingPerson.DateOfBirth = person.DateOfBirth;
					existingPerson.Gender = person.Gender;
					db.SaveChanges();
				}
				return person.ID;
			}
		}
	}
}