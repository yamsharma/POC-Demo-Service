using Moq;
using POCDemoApp.Domain.Repository.Interfaces.Core;
using POCDemoApp.Infrastructure.DataAccess.Context;
using Xunit;

namespace POCDemoApp.Infrastructure.DataAccess.Tests.UnitOfWork.Tests
{
	public class UnitOfWorkTests
	{
		private readonly Mock<EdgeDbContext> _mockContext;
		private readonly IUnitOfWork _unitOfWork;

		public UnitOfWorkTests()
		{
			_mockContext = new Mock<EdgeDbContext>();
			_unitOfWork = new DataAccess.UnitOfWork.UnitOfWork(_mockContext.Object);
		}

		#region Complete

		[Fact]
		public void Complete_WhenCalled_CallsSaveChangesOnContext()
		{
			// Arrange
			_mockContext.Setup(context => context.SaveChanges()).Returns(1);

			// Act
			var result = _unitOfWork.Complete();

			// Assert
			_mockContext.Verify(context => context.SaveChanges(), Times.Exactly(1));
			Assert.Equal(1, result);
		}

		#endregion
	}
}
