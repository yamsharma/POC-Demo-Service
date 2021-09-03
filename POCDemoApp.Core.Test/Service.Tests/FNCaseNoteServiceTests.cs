using AutoMapper;
using Moq;
using POCDemoApp.Core.Api.Entities;
using POCDemoApp.Core.Service.Interfaces;
using POCDemoApp.Core.Services;
using POCDemoApp.Domain.Commands.FnCaseNoteCommands;
using POCDemoApp.Domain.Core.Bus;
using POCDemoApp.Domain.Repository.Interfaces.Core;
using System;
using System.Collections.Generic;
using Xunit;

namespace POCDemoApp.Core.Tests.Service.Tests
{
	public class FnCaseNoteServiceTests
	{
		private readonly Mock<IUnitOfWork> _mockUnitOfWork;
		private readonly Mock<IMediatorHandler> _mockBus;
		private readonly Mock<IMapper> _mockAutoMapper;
		private readonly IFnCaseNoteService _service;

		public FnCaseNoteServiceTests()
		{
			_mockUnitOfWork = new Mock<IUnitOfWork>();
			_mockBus = new Mock<IMediatorHandler>();
			_mockAutoMapper = new Mock<IMapper>();
			_service = new FnCaseNoteService(_mockUnitOfWork.Object, _mockBus.Object, _mockAutoMapper.Object);
		}

		#region Add

		[Fact]
		public void Add_NullArgumentPassed_ThrowsArgumentNullException()
		{
			// Act and Assert
			Assert.Throws<ArgumentNullException>(() => _service.Add(null));
		}

		[Theory]
		[MemberData(nameof(AddDataSet.GetInvalidDataSet), MemberType = typeof(AddDataSet))]
		public void Add_InvalidCaseNotePassed_ThrowsArgumentException(FnCaseNoteApiModel caseNote)
		{
			// Act and Assert
			Assert.Throws<ArgumentException>(() => _service.Add(caseNote));
		}

		[Theory]
		[MemberData(nameof(AddDataSet.GetValidDataSet), MemberType = typeof(AddDataSet))]
		public void Add_ValidCaseNotePassed_CallsBusSendCommandOnce(FnCaseNoteApiModel caseNote)
		{
			// Arrange
			var autoMapperResult = new CreateFnCaseNoteCommand
			{
				Id = caseNote.Id,
				Title = caseNote.Title,
				ForeignNationalId = caseNote.ForeignNationalId
			};

			_mockAutoMapper.Setup(mapper => mapper.Map<CreateFnCaseNoteCommand>(caseNote))
				.Returns(autoMapperResult);

			// Act
			_service.Add(caseNote);

			// Assert
			_mockBus.Verify(bus => bus.SendCommand(autoMapperResult), Times.Exactly(1));
		}

		#endregion

		#region UpdateTitle

		[Fact]
		public void UpdateTitle_NullArgumentPassed_ThrowsArgumentNullException()
		{
			// Act and Assert
			Assert.Throws<ArgumentNullException>(() => _service.UpdateTitle(null));
		}

		[Theory]
		[MemberData(nameof(UpdateDeleteDataSet.GetInvalidDataSet), MemberType = typeof(UpdateDeleteDataSet))]
		public void UpdateTitle_InvalidCaseNotePassed_ThrowsArgumentException(FnCaseNoteApiModel caseNote)
		{
			// Act and Assert
			Assert.Throws<ArgumentException>(() => _service.UpdateTitle(caseNote));
		}

		[Theory]
		[MemberData(nameof(UpdateDeleteDataSet.GetValidDataSet), MemberType = typeof(UpdateDeleteDataSet))]
		public void UpdateTitle_ValidCaseNotePassed_CallsBusSendCommandOnce(FnCaseNoteApiModel caseNote)
		{
			// Arrange
			var autoMapperResult = new UpdateFnCaseNoteCommand
			{
				Id = caseNote.Id,
				Title = caseNote.Title,
				ForeignNationalId = caseNote.ForeignNationalId
			};

			_mockAutoMapper.Setup(mapper => mapper.Map<UpdateFnCaseNoteCommand>(caseNote))
				.Returns(autoMapperResult);

			// Act
			_service.UpdateTitle(caseNote);

			// Assert
			_mockBus.Verify(bus => bus.SendCommand(autoMapperResult), Times.Exactly(1));
		}

		#endregion

		#region Delete

		[Fact]
		public void Delete_NullArgumentPassed_ThrowsArgumentNullException()
		{
			// Act and Assert
			Assert.Throws<ArgumentNullException>(() => _service.Delete(null));
		}

		[Theory]
		[MemberData(nameof(UpdateDeleteDataSet.GetInvalidDataSet), MemberType = typeof(UpdateDeleteDataSet))]
		public void Delete_InvalidCaseNotePassed_ThrowsArgumentException(FnCaseNoteApiModel caseNote)
		{
			// Act and Assert
			Assert.Throws<ArgumentException>(() => _service.Delete(caseNote));
		}

		[Theory]
		[MemberData(nameof(UpdateDeleteDataSet.GetValidDataSet), MemberType = typeof(UpdateDeleteDataSet))]
		public void Delete_ValidCaseNotePassed_CallsBusSendCommandOnce(FnCaseNoteApiModel caseNote)
		{
			// Arrange
			var autoMapperResult = new DeleteFnCaseNoteCommand
			{
				Id = caseNote.Id,
				Title = caseNote.Title,
				ForeignNationalId = caseNote.ForeignNationalId
			};

			_mockAutoMapper.Setup(mapper => mapper.Map<DeleteFnCaseNoteCommand>(caseNote))
				.Returns(autoMapperResult);

			// Act
			_service.Delete(caseNote);

			// Assert
			_mockBus.Verify(bus => bus.SendCommand(autoMapperResult), Times.Exactly(1));
		}

		#endregion

		#region Unimplemented methods

		[Fact]
		public void Get_WhenCalled_ThrowsNotImplementedException()
		{
			// Act and Assert
			Assert.Throws<NotImplementedException>(() => _service.Get(1));
		}

		[Fact]
		public void GetAll_WhenCalled_ThrowsNotImplementedException()
		{
			// Act and Assert
			Assert.Throws<NotImplementedException>(() => _service.GetAll());
		}

		[Fact]
		public void Find_WhenCalled_ThrowsNotImplementedException()
		{
			// Act and Assert
			Assert.Throws<NotImplementedException>(() => _service.Find(c => c.Id == 1));
		}

		[Fact]
		public void AddRange_WhenCalled_ThrowsNotImplementedException()
		{
			// Act and Assert
			Assert.Throws<NotImplementedException>(() => _service.AddRange(null));
		}

		[Fact]
		public void DeleteRange_WhenCalled_ThrowsNotImplementedException()
		{
			// Act and Assert
			Assert.Throws<NotImplementedException>(() => _service.DeleteRange(null));
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
						new FnCaseNoteApiModel()
						{
							Id = 1,
							Title = "New Case Note",
							ForeignNationalId = 25
						}
					};

					// Id = 0
					yield return new object[]
					{
						new FnCaseNoteApiModel()
						{
							Title = "New Case Note",
							ForeignNationalId = 25
						}
					};
				}
			}

			public static IEnumerable<object[]> GetInvalidDataSet
			{
				get
				{
					// Id = 0, Title = null
					yield return new object[]
					{
						new FnCaseNoteApiModel
						{
							ForeignNationalId = 1
						}
					};

					// Title = null
					yield return new object[]
					{
						new FnCaseNoteApiModel
						{
							Id = 1,
							ForeignNationalId = 25
						}
					};

					// Title = empty string
					yield return new object[]
					{
						new FnCaseNoteApiModel
						{
							Id = 1,
							Title = "",
							ForeignNationalId = 25
						}
					};

					// ForeignNationalId = 0
					yield return new object[]
					{
						new FnCaseNoteApiModel
						{
							Id = 1,
							Title = "New Case Note"
						}
					};

					// ForeignNationalId = -1
					yield return new object[]
					{
						new FnCaseNoteApiModel
						{
							Id = 1,
							Title = "New Case Note",
							ForeignNationalId = -1
						}
					};
				}
			}
		}

		private static class UpdateDeleteDataSet
		{
			public static IEnumerable<object[]> GetValidDataSet
			{
				get
				{
					// full valid object
					yield return new object[]
					{
						new FnCaseNoteApiModel()
						{
							Id = 1,
							Title = "New Title",
							ForeignNationalId = 25
						}
					};
				}
			}

			public static IEnumerable<object[]> GetInvalidDataSet
			{
				get
				{
					// Id = 0
					yield return new object[]
					{
						new FnCaseNoteApiModel
						{
							Title = "New Title",
							ForeignNationalId = 25
						}
					};

					// Id = -1
					yield return new object[]
					{
						new FnCaseNoteApiModel
						{
							Id = -1,
							Title = "New Title",
							ForeignNationalId = 25
						}
					};

					// Id = 0, Title = null
					yield return new object[]
					{
						new FnCaseNoteApiModel
						{
							ForeignNationalId = 1
						}
					};

					// Title = null
					yield return new object[]
					{
						new FnCaseNoteApiModel
						{
							Id = 1,
							ForeignNationalId = 25
						}
					};

					// Title = empty string
					yield return new object[]
					{
						new FnCaseNoteApiModel
						{
							Id = 1,
							Title = "",
							ForeignNationalId = 25
						}
					};

					// ForeignNationalId = 0
					yield return new object[]
					{
						new FnCaseNoteApiModel
						{
							Id = 1,
							Title = "New Case Note"
						}
					};

					// ForeignNationalId = -1
					yield return new object[]
					{
						new FnCaseNoteApiModel
						{
							Id = 1,
							Title = "New Case Note",
							ForeignNationalId = -1
						}
					};
				}
			}
		}

		#endregion
	}
}
