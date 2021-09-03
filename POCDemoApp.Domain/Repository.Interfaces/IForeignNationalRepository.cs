using POCDemoApp.Domain.Entities;
using System.Collections.Generic;
using POCDemoApp.Domain.Repository.Interfaces.Core;

namespace POCDemoApp.Domain.Repository.Interfaces
{
	public interface IForeignNationalRepository : IRepository<ForeignNational>
	{
		#region Get methods
		IEnumerable<FnCaseNote> GetCaseNotes(long id);
		#endregion
	}
}
