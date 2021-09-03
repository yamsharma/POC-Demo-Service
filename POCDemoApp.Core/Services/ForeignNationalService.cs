using AutoMapper;
using POCDemoApp.Core.Api.Entities;
using POCDemoApp.Core.Service.Interfaces;
using POCDemoApp.Core.Services.Core;
using POCDemoApp.Domain.Core.Bus;
using POCDemoApp.Domain.Repository.Interfaces.Core;
using System.Collections.Generic;

namespace POCDemoApp.Core.Services
{
	public class ForeignNationalService : Service<ForeignNationalApiModel>, IForeignNationalService
	{
		public ForeignNationalService(IUnitOfWork unitOfWork, IMediatorHandler bus, IMapper autoMapper)
			: base(unitOfWork, bus, autoMapper)
		{ }

		#region Read Actions
		public new ForeignNationalApiModel Get(long id)
		{
			var foreignNational = UnitOfWork.ForeignNationals.Get(id);
			return AutoMapper.Map<ForeignNationalApiModel>(foreignNational);
		}

		public IEnumerable<FnCaseNoteApiModel> GetCaseNotes(long id)
		{
			var caseNotes = UnitOfWork.ForeignNationals.GetCaseNotes(id);
			return AutoMapper.Map<IEnumerable<FnCaseNoteApiModel>>(caseNotes);
		}
		#endregion
	}
}
