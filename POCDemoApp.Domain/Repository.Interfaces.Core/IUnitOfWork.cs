namespace POCDemoApp.Domain.Repository.Interfaces.Core
{
	public interface IUnitOfWork
	{
		IFnCaseNoteRepository FnCaseNotes { get; }
		IForeignNationalRepository ForeignNationals { get; }

		int Complete();
	}
}
