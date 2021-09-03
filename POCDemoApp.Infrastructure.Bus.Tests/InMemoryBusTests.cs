using MediatR;
using Moq;
using POCDemoApp.Domain.Commands.FnCaseNoteCommands;
using POCDemoApp.Domain.Core.Bus;
using Xunit;

namespace POCDemoApp.Infrastructure.Bus.Tests
{
	public class InMemoryBusTests
	{
		private readonly Mock<IMediator> _mockMediator;
		private readonly IMediatorHandler _bus;

		public InMemoryBusTests()
		{
			_mockMediator = new Mock<IMediator>();
			_bus = new InMemoryBus(_mockMediator.Object);
		}

		#region SendCommand

		[Fact]
		public void SendCommand_WhenCalled_CallsSendOnMediator()
		{
			// Arrange
			var command = new CreateFnCaseNoteCommand();

			// Act
			_bus.SendCommand(command);

			// Assert
			_mockMediator.Verify(mediator => mediator.Send(It.IsAny<CreateFnCaseNoteCommand>(), default), Times.Exactly(1));
		}

		#endregion
	}
}
