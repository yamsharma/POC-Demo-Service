namespace POCDemoApp.Domain.Entity.Interfaces.Core
{
	public interface ICaseNote : IEntity
	{
		string Title { get; set; }
		byte ForeignKeyTable { get; }
		long ForeignKeyId { get; set; }
	}
}
