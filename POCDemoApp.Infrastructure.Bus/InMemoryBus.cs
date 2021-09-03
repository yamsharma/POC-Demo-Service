using MediatR;
using POCDemoApp.Domain.Core.Bus;
using POCDemoApp.Domain.Core.Commands;
using System.Threading.Tasks;

namespace POCDemoApp.Infrastructure.Bus
{
	public sealed class InMemoryBus : IMediatorHandler
	{
		private readonly IMediator _mediator;

		public InMemoryBus(IMediator mediator)
		{
			_mediator = mediator;
		}

		public Task SendCommand<T>(T command) where T : Command
		{
			return _mediator.Send(command);
		}
	}
}
