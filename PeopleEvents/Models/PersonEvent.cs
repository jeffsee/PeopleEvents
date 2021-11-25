namespace PeopleEvents.Models
{
	/// <summary>
	/// Model the link between person and event for the EF database
	/// </summary>
	public class PersonEvent
	{
		public int ID { get; set; }
		public int PersonID { get; set; }
		public int EventID { get; set; }
	}
}