using POCDemoApp.Domain.Entity.Interfaces.Core;

namespace POCDemoApp.Core.Api.Entities
{
	public class ForeignNationalApiModel : IEntity
	{
		public long Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
	}
}
