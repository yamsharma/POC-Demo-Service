using POCDemoApp.Domain.Repository.Interfaces;
using POCDemoApp.Domain.Repository.Interfaces.Core;
using POCDemoApp.Infrastructure.DataAccess.Context;
using POCDemoApp.Infrastructure.DataAccess.Repositories;

namespace POCDemoApp.Infrastructure.DataAccess.UnitOfWork
{
	public class UnitOfWork : IUnitOfWork
	{
		public IFnCaseNoteRepository FnCaseNotes { get; }

		public IForeignNationalRepository ForeignNationals { get; }

		private readonly EdgeDbContext _context;

		public UnitOfWork(EdgeDbContext context)
		{
			_context = context;
			FnCaseNotes = new FnCaseNoteRepository(_context);
			ForeignNationals = new ForeignNationalRepository(_context);
		}

		public int Complete()
		{
			return _context.SaveChanges();
		}
	}
}
