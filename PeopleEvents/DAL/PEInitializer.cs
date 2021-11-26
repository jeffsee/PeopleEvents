using PeopleEvents.Models;
using System;
using System.Collections.Generic;

namespace PeopleEvents.DAL
{
	public class PEInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<PEContext>
	{
		/// <summary>
		/// Create some sample initial data to use for the demo
		/// </summary>
		/// <param name="context"></param>
		protected override void Seed(PEContext context)
		{
			var people = new List<Person>
			{
				new Person { ID = 1, Name = "John Doe", DateOfBirth = new DateTime(1990, 1, 1), Gender = "M" },
				new Person { ID = 2, Name = "Jane Smith", DateOfBirth = new DateTime(1995, 12, 1), Gender = "F" },
				new Person { ID = 3, Name = "Max Power", DateOfBirth = new DateTime(1985, 6, 14), Gender = "M" }
			};

			people.ForEach(p => context.People.Add(p));
			context.SaveChanges();

			var events = new List<Event>
			{
				new Event { ID = 1, PersonName = "John Doe", DateOfBirth = new DateTime(1990, 1, 1), EventDateTime = new DateTime(1990, 1, 1), EventDescription = "Birth" },
				new Event { ID = 2, PersonName = "John Doe", DateOfBirth = new DateTime(1990, 1, 1), EventDateTime = new DateTime(2008, 12, 15), EventDescription = "Operation: Appendix Removal" },
				new Event { ID = 3, PersonName = "Jane Smith", DateOfBirth = new DateTime(1995, 12, 1), EventDateTime = new DateTime(1995, 12, 1), EventDescription = "Birth" },
				new Event { ID = 4, PersonName = "Jane Smith", DateOfBirth = new DateTime(1995, 12, 1), EventDateTime = new DateTime(2009, 4, 4), EventDescription = "Hospital Admission: Broken Bone" },
				new Event { ID = 5, PersonName = "Jane Smith", DateOfBirth = new DateTime(1995, 12, 1), EventDateTime = new DateTime(2021, 7, 8), EventDescription = "Operation: Caesarean Section" },
				new Event { ID = 6, PersonName = "Max Power", DateOfBirth = new DateTime(1985, 6, 14), EventDateTime = new DateTime(1985, 6, 14), EventDescription = "Birth" }
			};

			events.ForEach(e => context.Events.Add(e));
			context.SaveChanges();

			var peopleEvents = new List<PersonEvent>
			{
				new PersonEvent { ID = 1, PersonID = 1, EventID = 1 },
				new PersonEvent { ID = 2, PersonID = 1, EventID = 2 },
				new PersonEvent { ID = 3, PersonID = 2, EventID = 3 },
				new PersonEvent { ID = 4, PersonID = 2, EventID = 4 },
				new PersonEvent { ID = 5, PersonID = 2, EventID = 5 },
				new PersonEvent { ID = 6, PersonID = 3, EventID = 6 }
			};

			peopleEvents.ForEach(pe => context.PersonEvents.Add(pe));
			context.SaveChanges();
		}
	}
}