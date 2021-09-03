using Microsoft.AspNetCore.Mvc;
using Moq;
using POCDemoApp.API.Controllers;
using POCDemoApp.Core.Api.Entities;
using POCDemoApp.Core.Service.Interfaces;
using System;
using System.Collections.Generic;
using Xunit;

namespace POCDemoApp.API.Tests.Controller.Tests
{
	public class FnCaseNotesControllerTests
	{
		private readonly Mock<IFnCaseNoteService> _mockService;
		private readonly FnCaseNotesController _controller;

		public FnCaseNotesControllerTests()
		{
			_mockService = new Mock<IFnCaseNoteService>();
			_controller = new FnCaseNotesController(_mockService.Object);
		}

		#region Add

		[Theory]
		[MemberData(nameof(AddDataSet.GetInvalidDataSet), MemberType = typeof(AddDataSet))]
		public void Add_InvalidCaseNotePassed_ReturnsBadRequest(FnCaseNoteApiModel caseNote)
		{
			// Arrange
			_mockService.Setup(service => service.Add(null))
				.Throws(Mock.Of<ArgumentNullException>());

			_mockService.Setup(service => service.Add(caseNote))
				.Throws(Mock.Of<ArgumentException>());

			// Act
			var actionResult = _controller.Add(caseNote);

			// Assert
			Assert.IsType<BadRequestResult>(actionResult);
		}

		[Theory]
		[MemberData(nameof(AddDataSet.GetValidDataSet), MemberType = typeof(AddDataSet))]
		public void Add_ValidCaseNotePassed_ReturnsOkResult(FnCaseNoteApiModel caseNote)
		{
			// Act
			var actionResult = _controller.Add(caseNote);

			// Assert
			Assert.IsType<OkResult>(actionResult);
		}

		#endregion

		#region UpdateTitle

		[Theory]
		[MemberData(nameof(UpdateDeleteDataSet.GetInvalidDataSet), MemberType = typeof(UpdateDeleteDataSet))]
		public void UpdateTitle_InvalidCaseNotePassed_ReturnsBadRequest(FnCaseNoteApiModel caseNote)
		{
			// Arrange
			_mockService.Setup(service => service.UpdateTitle(null))
				.Throws(Mock.Of<ArgumentNullException>());

			_mockService.Setup(service => service.UpdateTitle(caseNote))
				.Throws(Mock.Of<ArgumentException>());

			// Act
			var actionResult = _controller.UpdateTitle(caseNote);

			// Assert
			Assert.IsType<BadRequestResult>(actionResult);
		}

		[Theory]
		[MemberData(nameof(UpdateDeleteDataSet.GetValidDataSet), MemberType = typeof(UpdateDeleteDataSet))]
		public void UpdateTitle_ValidCaseNotePassed_ReturnsOkResult(FnCaseNoteApiModel caseNote)
		{
			// Act
			var actionResult = _controller.UpdateTitle(caseNote);

			// Assert
			Assert.IsType<OkResult>(actionResult);
		}

		#endregion

		#region Delete

		[Theory]
		[MemberData(nameof(UpdateDeleteDataSet.GetInvalidDataSet), MemberType = typeof(UpdateDeleteDataSet))]
		public void Delete_InvalidCaseNotePassed_ReturnsBadRequest(FnCaseNoteApiModel caseNote)
		{
			// Arrange
			_mockService.Setup(service => service.Delete(null))
				.Throws(Mock.Of<ArgumentNullException>());

			_mockService.Setup(service => service.Delete(caseNote))
				.Throws(Mock.Of<ArgumentException>());

			// Act
			var actionResult = _controller.Delete(caseNote);

			// Assert
			Assert.IsType<BadRequestResult>(actionResult);
		}

		[Theory]
		[MemberData(nameof(UpdateDeleteDataSet.GetValidDataSet), MemberType = typeof(UpdateDeleteDataSet))]
		public void Delete_ValidCaseNotePassed_ReturnsOkResult(FnCaseNoteApiModel caseNote)
		{
			// Act
			var actionResult = _controller.Delete(caseNote);

			// Assert
			Assert.IsType<OkResult>(actionResult);
		}

		#endregion

		#region Unimplemented methods

		[Fact]
		public void Get_WhenCalled_ThrowsNotImplementedException()
		{
			// Act and Assert
			Assert.ThrowsAsync<NotImplementedException>(() => _controller.Get(1));
		}

		[Fact]
		public void GetAll_WhenCalled_ThrowsNotImplementedException()
		{
			// Act and Assert
			Assert.ThrowsAsync<NotImplementedException>(() => _controller.GetAll());
		}

		[Fact]
		public void Find_WhenCalled_ThrowsNotImplementedException()
		{
			// Act and Assert
			Assert.ThrowsAsync<NotImplementedException>(() => _controller.Find(c => c.Id == 1));
		}

		[Fact]
		public void AddRange_WhenCalled_ThrowsNotImplementedException()
		{
			// Act and Assert
			Assert.Throws<NotImplementedException>(() => _controller.AddRange(null));
		}

		[Fact]
		public void Update_WhenCalled_ThrowsNotImplementedException()
		{
			// Act and Assert
			Assert.Throws<NotImplementedException>(() => _controller.Update(null));
		}

		[Fact]
		public void DeleteRange_WhenCalled_ThrowsNotImplementedException()
		{
			// Act and Assert
			Assert.Throws<NotImplementedException>(() => _controller.DeleteRange(null));
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
					// null object
					yield return new object[]
					{
						null
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
					// null object
					yield return new object[]
					{
						null
					};

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