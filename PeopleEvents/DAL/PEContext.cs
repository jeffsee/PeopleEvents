using PeopleEvents.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PeopleEvents.DAL
{
	/// <summary>
	/// Set up the Entity Framework database first context
	/// </summary>
	public class PEContext : DbContext
	{
		public PEContext() : base("PEContext") { }

		public virtual DbSet<Person> People { get; set; }
		public virtual DbSet<Event> Events { get; set; }
		public virtual DbSet<PersonEvent> PersonEvents { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}
	}
}