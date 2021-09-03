using AutoMapper;
using MediatR;
using POCDemoApp.Domain.CommandHandlers.Core;
using POCDemoApp.Domain.Commands.FnCaseNoteCommands;
using POCDemoApp.Domain.Entities;
using POCDemoApp.Domain.Repository.Interfaces.Core;
using System.Threading;
using System.Threading.Tasks;

namespace POCDemoApp.Domain.CommandHandlers
{
	public class FnCaseNoteCommandHandler : CommandHandler,
		IRequestHandler<CreateFnCaseNoteCommand, int>,
		IRequestHandler<UpdateFnCaseNoteCommand, int>,
		IRequestHandler<DeleteFnCaseNoteCommand, int>
	{
		public FnCaseNoteCommandHandler(IUnitOfWork unitOfWork, IMapper autoMapper)
			: base(unitOfWork, autoMapper)
		{ }

		public async Task<int> Handle(CreateFnCaseNoteCommand createFnCaseNoteCommand, CancellationToken cancellationToken)
		{
			var caseNote = AutoMapper.Map<FnCaseNote>(createFnCaseNoteCommand);

			UnitOfWork.FnCaseNotes.Add(caseNote);
			return await Task.FromResult(UnitOfWork.Complete());
		}

		public async Task<int> Handle(UpdateFnCaseNoteCommand updateFnCaseNoteCommand, CancellationToken cancellationToken)
		{
			var caseNote = AutoMapper.Map<FnCaseNote>(updateFnCaseNoteCommand);

			UnitOfWork.FnCaseNotes.UpdateTitle(caseNote);
			return await Task.FromResult(UnitOfWork.Complete());
		}

		public async Task<int> Handle(DeleteFnCaseNoteCommand deleteFnCaseNoteCommand, CancellationToken cancellationToken)
		{
			var caseNote = AutoMapper.Map<FnCaseNote>(deleteFnCaseNoteCommand);

			UnitOfWork.FnCaseNotes.Delete(caseNote);
			return await Task.FromResult(UnitOfWork.Complete());
		}
	}
}
