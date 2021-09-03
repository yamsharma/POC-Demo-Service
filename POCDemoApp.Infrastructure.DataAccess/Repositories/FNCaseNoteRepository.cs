using POCDemoApp.Domain.Entities;
using POCDemoApp.Domain.Repository.Interfaces;
using POCDemoApp.Infrastructure.DataAccess.Context;
using POCDemoApp.Infrastructure.DataAccess.Repositories.Core;

namespace POCDemoApp.Infrastructure.DataAccess.Repositories
{
	public class FnCaseNoteRepository : Repository<FnCaseNote>, IFnCaseNoteRepository
	{
		private readonly EdgeDbContext _edgeDbContext;

		public FnCaseNoteRepository(EdgeDbContext context)
			: base(context)
		{
			_edgeDbContext = Context as EdgeDbContext;
		}

		#region Update methods
		public void UpdateTitle(FnCaseNote note)
		{
			var caseNote = _edgeDbContext.CaseNotes.Find(note.Id);
			caseNote.Title = note.Title;
		}
		#endregion
	}
}
