using POCDemoApp.Core.Api.Entities;
using POCDemoApp.Core.Service.Interfaces.Core;

namespace POCDemoApp.Core.Service.Interfaces
{
	public interface IFnCaseNoteService : IService<FnCaseNoteApiModel>
	{
		void UpdateTitle(FnCaseNoteApiModel caseNoteApiModel);
	}
}
