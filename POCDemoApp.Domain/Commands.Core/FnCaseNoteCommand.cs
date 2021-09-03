using POCDemoApp.Domain.Core.Commands;

namespace POCDemoApp.Domain.Commands.Core
{
	public abstract class FnCaseNoteCommand : Command
	{
		public long Id { get; set; }
		public string Title { get; set; }
		public long ForeignNationalId { get; set; }
	}
}
