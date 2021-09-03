using POCDemoApp.Core.Api.Entities;
using POCDemoApp.Core.Service.Interfaces.Core;
using System.Collections.Generic;

namespace POCDemoApp.Core.Service.Interfaces
{
	public interface IForeignNationalService : IService<ForeignNationalApiModel>
	{
		#region Get methods
		IEnumerable<FnCaseNoteApiModel> GetCaseNotes(long id);
		#endregion
	}
}
