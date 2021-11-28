using Moq;
using NUnit.Framework;
using PeopleEvents.DAL;
using PeopleEvents.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PeopleEvents.Test
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void Test_PersonService_GetPeople_ReturnsEmpty()
		{
			// Arrange
			var data = new List<Person>
			{
				
			}.AsQueryable();

			var mockSet = new Mock<DbSet<Person>>();
			mockSet.As<IQueryable<Person>>().Setup(m => m.Provider).Returns(data.Provider);
			mockSet.As<IQueryable<Person>>().Setup(m => m.Expression).Returns(data.Expression);
			mockSet.As<IQueryable<Person>>().Setup(m => m.ElementType).Returns(data.ElementType);
			mockSet.As<IQueryable<Person>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

			var mockContext = new Mock<PEContext>();
			mockContext.Setup(m => m.People).Returns(mockSet.Object);

			// Act
			var service = new PersonService(mockContext.Object);
			var people = service.GetPeople();

			// Assert
			Assert.AreEqual(0, people.Count);
		}

		[Test]
		public void Test_PersonService_GetPeople_ReturnsCorrectly()
		{
			// Arrange
			var data = new List<Person>
			{
				new Person { ID = 1, Name = "Person 1", DateOfBirth = new System.DateTime(2000, 1, 1), Gender = "F" },
				new Person { ID = 2, Name = "Person 2", DateOfBirth = new System.DateTime(2000, 1, 1), Gender = "M" },
				new Person { ID = 3, Name = "Person 3", DateOfBirth = new System.DateTime(2000, 1, 1), Gender = "" }
			}.AsQueryable();

			var mockSet = new Mock<DbSet<Person>>();
			mockSet.As<IQueryable<Person>>().Setup(m => m.Provider).Returns(data.Provider);
			mockSet.As<IQueryable<Person>>().Setup(m => m.Expression).Returns(data.Expression);
			mockSet.As<IQueryable<Person>>().Setup(m => m.ElementType).Returns(data.ElementType);
			mockSet.As<IQueryable<Person>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

			var mockContext = new Mock<PEContext>();
			mockContext.Setup(m => m.People).Returns(mockSet.Object);

			// Act
			var service = new PersonService(mockContext.Object);
			var people = service.GetPeople();

			// Assert
			Assert.AreEqual(3, people.Count);
		}

		[Test]
		public void Test_PersonService_GetPerson_ReturnsCorrectly()
		{
			// Arrange
			var data = new List<Person>
			{
				new Person { ID = 1, Name = "Person 1", DateOfBirth = new System.DateTime(2000, 1, 1), Gender = "F" },
				new Person { ID = 2, Name = "Person 2", DateOfBirth = new System.DateTime(2000, 1, 1), Gender = "M" },
				new Person { ID = 3, Name = "Person 3", DateOfBirth = new System.DateTime(2000, 1, 1), Gender = "" }
			}.AsQueryable();

			var mockSet = new Mock<DbSet<Person>>();
			mockSet.As<IQueryable<Person>>().Setup(m => m.Provider).Returns(data.Provider);
			mockSet.As<IQueryable<Person>>().Setup(m => m.Expression).Returns(data.Expression);
			mockSet.As<IQueryable<Person>>().Setup(m => m.ElementType).Returns(data.ElementType);
			mockSet.As<IQueryable<Person>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

			var mockContext = new Mock<PEContext>();
			mockContext.Setup(m => m.People).Returns(mockSet.Object);
			mockSet.Setup(m => m.Find(2)).Returns(data.Where(x => x.ID == 2).FirstOrDefault());

			// Act
			var service = new PersonService(mockContext.Object);
			var person = service.GetPerson(2);

			// Assert
			Assert.AreEqual(2, person.ID);
			Assert.AreEqual("Person 2", person.Name);
		}

		[Test]
		public void Test_PersonService_GetPerson_ReturnsNullOnInvalidID()
		{
			// Arrange
			var data = new List<Person>
			{
				new Person { ID = 1, Name = "Person 1", DateOfBirth = new System.DateTime(2000, 1, 1), Gender = "F" },
				new Person { ID = 2, Name = "Person 2", DateOfBirth = new System.DateTime(2000, 1, 1), Gender = "M" },
				new Person { ID = 3, Name = "Person 3", DateOfBirth = new System.DateTime(2000, 1, 1), Gender = "" }
			}.AsQueryable();

			var mockSet = new Mock<DbSet<Person>>();
			mockSet.As<IQueryable<Person>>().Setup(m => m.Provider).Returns(data.Provider);
			mockSet.As<IQueryable<Person>>().Setup(m => m.Expression).Returns(data.Expression);
			mockSet.As<IQueryable<Person>>().Setup(m => m.ElementType).Returns(data.ElementType);
			mockSet.As<IQueryable<Person>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

			var mockContext = new Mock<PEContext>();
			mockContext.Setup(m => m.People).Returns(mockSet.Object);

			// Act
			var service = new PersonService(mockContext.Object);
			var person = service.GetPerson(4);

			// Assert
			Assert.IsNull(person);
		}

		[Test]
		public void Test_PersonService_SavePerson_CreatesANewPerson()
		{
			// Arrange
			var newPerson = new Person() { ID = 0, Name = "New Person", DateOfBirth = new System.DateTime(2000, 1, 1), Gender = "" };

			var mockContext = new Mock<PEContext>();
			var mockSet = new Mock<DbSet<Person>>();
			
			mockContext.Setup(m => m.People).Returns(mockSet.Object);

			// Act
			var service = new PersonService(mockContext.Object);
			service.SavePerson(newPerson);

			// Assert
			mockSet.Verify(m => m.Add(It.IsAny<Person>()), Times.Once);
			mockContext.Verify(m => m.SaveChanges(), Times.Once);
		}
	}
}