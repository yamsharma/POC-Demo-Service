using AutoMapper;
using POCDemoApp.Domain.Repository.Interfaces.Core;

namespace POCDemoApp.Domain.CommandHandlers.Core
{
	public abstract class CommandHandler
	{
		protected readonly IUnitOfWork UnitOfWork;
		protected readonly IMapper AutoMapper;

		protected CommandHandler(IUnitOfWork unitOfWork, IMapper autoMapper)
		{
			UnitOfWork = unitOfWork;
			AutoMapper = autoMapper;
		}
	}
}
