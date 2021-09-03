using POCDemoApp.Domain.Entity.Interfaces.Core;

namespace POCDemoApp.Domain.Entities
{
	public class FnCaseNote : ICaseNote
	{
		public long Id { get; set; }
		public string Title { get; set; }
		public byte ForeignKeyTable { get; }
		public long ForeignKeyId { get; set; }
		public ForeignNational ForeignNational { get; set; }

		public FnCaseNote()
		{
			ForeignKeyTable = 14;
		}
	}
}
