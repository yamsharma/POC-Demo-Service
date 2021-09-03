using POCDemoApp.Domain.Entity.Interfaces.Core;

namespace POCDemoApp.Core.Api.Entities
{
	public class FnCaseNoteApiModel : IEntity
	{
		public long Id { get; set; }
		public string Title { get; set; }
		public long ForeignNationalId { get; set; }
	}
}
