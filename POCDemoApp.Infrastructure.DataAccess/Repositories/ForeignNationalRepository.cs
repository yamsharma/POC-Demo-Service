using POCDemoApp.Domain.Entities;
using POCDemoApp.Domain.Repository.Interfaces;
using POCDemoApp.Infrastructure.DataAccess.Context;
using POCDemoApp.Infrastructure.DataAccess.Repositories.Core;
using System.Collections.Generic;
using System.Linq;

namespace POCDemoApp.Infrastructure.DataAccess.Repositories
{
	public class ForeignNationalRepository : Repository<ForeignNational>, IForeignNationalRepository
	{
		private readonly EdgeDbContext _edgeDbContext;

		public ForeignNationalRepository(EdgeDbContext context)
			: base(context)
		{
			_edgeDbContext = Context as EdgeDbContext;
		}

		#region Get methods
		public IEnumerable<FnCaseNote> GetCaseNotes(long id)
		{
			return _edgeDbContext.ForeignNationals
				.Where(f => f.Id == id)
				.SelectMany(f => f.CaseNotes);
		}
		#endregion
	}
}
