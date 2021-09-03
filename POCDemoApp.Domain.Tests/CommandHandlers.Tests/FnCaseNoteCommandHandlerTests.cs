using AutoMapper;
using Moq;
using POCDemoApp.Domain.CommandHandlers;
using POCDemoApp.Domain.Commands.FnCaseNoteCommands;
using POCDemoApp.Domain.Entities;
using POCDemoApp.Domain.Repository.Interfaces;
using POCDemoApp.Domain.Repository.Interfaces.Core;
using System.Collections.Generic;
using System.Threading;
using Xunit;

namespace POCDemoApp.Domain.Tests.CommandHandlers.Tests
{
	public class FnCaseNoteCommandHandlerTests
	{
		private readonly Mock<IUnitOfWork> _mockUnitOfWork;
		private readonly Mock<IMapper> _mockAutoMapper;
		private readonly Mock<IFnCaseNoteRepository> _mockRepository;
		private readonly FnCaseNoteCommandHandler _commandHandler;

		public FnCaseNoteCommandHandlerTests()
		{
			_mockUnitOfWork = new Mock<IUnitOfWork>();
			_mockAutoMapper = new Mock<IMapper>();
			_commandHandler = new FnCaseNoteCommandHandler(_mockUnitOfWork.Object, _mockAutoMapper.Object);
			_mockRepository = new Mock<IFnCaseNoteRepository>();
		}

		#region Handle_CreateFnCaseNoteCommand

		[Theory]
		[MemberData(nameof(AddDataSet.GetValidDataSet), MemberType = typeof(AddDataSet))]
		public void Handle_CreateFnCaseNoteCommand_ValidCaseNotePassed_ReturnsOne(CreateFnCaseNoteCommand createCaseNoteCommand)
		{
			// Arrange
			var autoMapperResult = new FnCaseNote
			{
				Id = createCaseNoteCommand.Id,
				Title = createCaseNoteCommand.Title,
				ForeignKeyId = createCaseNoteCommand.ForeignNationalId
			};

			_mockAutoMapper.Setup(mapper => mapper.Map<FnCaseNote>(createCaseNoteCommand))
				.Returns(autoMapperResult);

			_mockUnitOfWork.Setup(unitOfWork => unitOfWork.FnCaseNotes).Returns(_mockRepository.Object);

			_mockUnitOfWork.Setup(unitOfWork => unitOfWork.Complete()).Returns(1);

			// Act
			var result = _commandHandler.Handle(createCaseNoteCommand, CancellationToken.None);

			// Assert
			_mockRepository.Verify(repository => repository.Add(autoMapperResult), Times.Exactly(1));
			_mockUnitOfWork.Verify(unitOfWork => unitOfWork.Complete(), Times.Exactly(1));
			Assert.Equal(1, result.Result);
		}

		#endregion

		#region Handle_UpdateFnCaseNoteCommand

		[Theory]
		[MemberData(nameof(UpdateDataSet.GetValidDataSet), MemberType = typeof(UpdateDataSet))]
		public void Handle_UpdateFnCaseNoteCommand_ValidCaseNotePassed_ReturnsOne(UpdateFnCaseNoteCommand updateCaseNoteCommand)
		{
			// Arrange
			var autoMapperResult = new FnCaseNote
			{
				Id = updateCaseNoteCommand.Id,
				Title = updateCaseNoteCommand.Title,
				ForeignKeyId = updateCaseNoteCommand.ForeignNationalId
			};

			_mockAutoMapper.Setup(mapper => mapper.Map<FnCaseNote>(updateCaseNoteCommand))
				.Returns(autoMapperResult);

			_mockUnitOfWork.Setup(unitOfWork => unitOfWork.FnCaseNotes).Returns(_mockRepository.Object);

			_mockUnitOfWork.Setup(unitOfWork => unitOfWork.Complete()).Returns(1);

			// Act
			var result = _commandHandler.Handle(updateCaseNoteCommand, CancellationToken.None);

			// Assert
			_mockRepository.Verify(repository => repository.UpdateTitle(autoMapperResult), Times.Exactly(1));
			_mockUnitOfWork.Verify(unitOfWork => unitOfWork.Complete(), Times.Exactly(1));
			Assert.Equal(1, result.Result);
		}

		#endregion

		#region Handle_CreateFnCaseNoteCommand

		[Theory]
		[MemberData(nameof(DeleteDataSet.GetValidDataSet), MemberType = typeof(DeleteDataSet))]
		public void Handle_DeleteFnCaseNoteCommand_ValidCaseNotePassed_ReturnsOne(DeleteFnCaseNoteCommand deleteCaseNoteCommand)
		{
			// Arrange
			var autoMapperResult = new FnCaseNote
			{
				Id = deleteCaseNoteCommand.Id,
				Title = deleteCaseNoteCommand.Title,
				ForeignKeyId = deleteCaseNoteCommand.ForeignNationalId
			};

			_mockAutoMapper.Setup(mapper => mapper.Map<FnCaseNote>(deleteCaseNoteCommand))
				.Returns(autoMapperResult);

			_mockUnitOfWork.Setup(unitOfWork => unitOfWork.FnCaseNotes).Returns(_mockRepository.Object);

			_mockUnitOfWork.Setup(unitOfWork => unitOfWork.Complete()).Returns(1);

			// Act
			var result = _commandHandler.Handle(deleteCaseNoteCommand, CancellationToken.None);

			// Assert
			_mockRepository.Verify(repository => repository.Delete(autoMapperResult), Times.Exactly(1));
			_mockUnitOfWork.Verify(unitOfWork => unitOfWork.Complete(), Times.Exactly(1));
			Assert.Equal(1, result.Result);
		}

		#endregion

		#region DataSets

		private static class AddDataSet
		{
			public static IEnumerable<object[]> GetValidDataSet
			{
				get
				{
					// full valid object
					yield return new object[]
					{
						new CreateFnCaseNoteCommand()
						{
							Id = 1,
							Title = "New Case Note",
							ForeignNationalId = 25
						}
					};

					// Id = 0
					yield return new object[]
					{
						new CreateFnCaseNoteCommand()
						{
							Title = "New Case Note",
							ForeignNationalId = 25
						}
					};
				}
			}
		}

		private static class UpdateDataSet
		{
			public static IEnumerable<object[]> GetValidDataSet
			{
				get
				{
					// full valid object
					yield return new object[]
					{
						new UpdateFnCaseNoteCommand()
						{
							Id = 1,
							Title = "New Title",
							ForeignNationalId = 25
						}
					};
				}
			}
		}

		private static class DeleteDataSet
		{
			public static IEnumerable<object[]> GetValidDataSet
			{
				get
				{
					// full valid object
					yield return new object[]
					{
						new DeleteFnCaseNoteCommand()
						{
							Id = 1,
							Title = "New Title",
							ForeignNationalId = 25
						}
					};
				}
			}
		}

		#endregion
	}
}
