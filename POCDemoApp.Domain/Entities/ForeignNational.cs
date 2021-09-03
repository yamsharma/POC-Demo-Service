using POCDemoApp.Domain.Entity.Interfaces;
using System.Collections.Generic;
using POCDemoApp.Domain.Entity.Interfaces.Core;

namespace POCDemoApp.Domain.Entities
{
	public class ForeignNational : IEntity
	{
		public long Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public IList<FnCaseNote> CaseNotes { get; set; }
	}
}
