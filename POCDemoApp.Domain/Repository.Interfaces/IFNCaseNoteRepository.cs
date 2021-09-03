using POCDemoApp.Domain.Entities;
using POCDemoApp.Domain.Repository.Interfaces.Core;

namespace POCDemoApp.Domain.Repository.Interfaces
{
	public interface IFnCaseNoteRepository : IRepository<FnCaseNote>
	{
		#region Update methods
		void UpdateTitle(FnCaseNote caseNote);
		#endregion
	}
}
