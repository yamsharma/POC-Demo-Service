using AutoMapper;
using POCDemoApp.Core.Api.Entities;
using POCDemoApp.Core.Service.Interfaces;
using POCDemoApp.Core.Services.Core;
using POCDemoApp.Domain.Commands;
using POCDemoApp.Domain.Core.Bus;
using POCDemoApp.Domain.Repository.Interfaces.Core;
using System;
using POCDemoApp.Domain.Commands.FnCaseNoteCommands;

namespace POCDemoApp.Core.Services
{
	public class FnCaseNoteService : Service<FnCaseNoteApiModel>, IFnCaseNoteService
	{
		public FnCaseNoteService(IUnitOfWork unitOfWork, IMediatorHandler bus, IMapper autoMapper)
			: base(unitOfWork, bus, autoMapper)
		{ }

		#region Add methods
		public new void Add(FnCaseNoteApiModel caseNoteApiModel)
		{
			if (caseNoteApiModel == null)
				throw new ArgumentNullException();

			if (string.IsNullOrEmpty(caseNoteApiModel.Title) || caseNoteApiModel.ForeignNationalId <= 0)
				throw new ArgumentException();

			var createCaseNoteCommand = AutoMapper.Map<CreateFnCaseNoteCommand>(caseNoteApiModel);

			Bus.SendCommand(createCaseNoteCommand);
		}
		#endregion

		#region Update methods
		public void UpdateTitle(FnCaseNoteApiModel caseNoteApiModel)
		{
			if (caseNoteApiModel == null)
				throw new ArgumentNullException();

			if (caseNoteApiModel.Id <= 0 || string.IsNullOrEmpty(caseNoteApiModel.Title) || caseNoteApiModel.ForeignNationalId <= 0)
				throw new ArgumentException();

			var updateCaseNoteCommand = AutoMapper.Map<UpdateFnCaseNoteCommand>(caseNoteApiModel);

			Bus.SendCommand(updateCaseNoteCommand);
		}
		#endregion

		#region Delete methods
		public new void Delete(FnCaseNoteApiModel caseNoteApiModel)
		{
			if (caseNoteApiModel == null)
				throw new ArgumentNullException();

			if (caseNoteApiModel.Id <= 0 || string.IsNullOrEmpty(caseNoteApiModel.Title) || caseNoteApiModel.ForeignNationalId <= 0)
				throw new ArgumentException();

			var deleteCaseNoteCommand = AutoMapper.Map<DeleteFnCaseNoteCommand>(caseNoteApiModel);

			Bus.SendCommand(deleteCaseNoteCommand);
		}
		#endregion
	}
}
